using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Customers;
using LibraryManagementSystem.Application.Services.Books;
using LibraryManagementSystem.Application.Services.Customers;
using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace LibraryManagementSystem.WebUI.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public CustomersController(ICustomerService service, IMapper mapper, IBookService bookService)
        {
            _service = service;
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, int? page)
        {
            var customers = await _service.GetAll(search);
            var model = _mapper.Map<IEnumerable<GetCustomerModel>>(customers);
            return View(model.ToPagedList(page ?? 1,5));
        }

        [HttpGet]
        [Route("Customers/Details/{customerId}")]
        public async Task<IActionResult> Details(int customerId, int? page, string search)
        {
            var customer = await _service.GetById(customerId);
            if(customer == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var books = await _bookService.GetBooksByCustomer(customerId, search);
            var model = new DetailsModel
            {
                Customer = _mapper.Map<GetCustomerModel>(customer),
                Books = _mapper.Map<IEnumerable<GetBookModel>>(books).ToPagedList(page ?? 1,5)
            };
            return View(model);
        }

        [HttpGet]
        [Route("Customers/Create")]
        public IActionResult Create()
        {
            return View(new CreateCustomerModel());
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _mapper.Map<CreateCustomerDto>(model);
                _service.Create(customer);
                return RedirectToAction("Index");  
            }
            return View(model);
        }

        [HttpGet]
        [Route("Customers/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _service.GetById(id);
            if(customer == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<UpdateCustomerModel>(customer);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<UpdateCustomerDto>(model);
                _service.Update(customer);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Customers/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _service.GetById(id);
            if (customer == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<GetCustomerModel>(customer);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
