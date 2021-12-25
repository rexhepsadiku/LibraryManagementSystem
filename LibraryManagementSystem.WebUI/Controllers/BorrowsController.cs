using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Borrows;
using LibraryManagementSystem.Application.Services.Books;
using LibraryManagementSystem.Application.Services.Borrows;
using LibraryManagementSystem.Application.Services.Customers;
using LibraryManagementSystem.Shared.Models.Borrows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace LibraryManagementSystem.WebUI.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class BorrowsController : Controller
    {
        private readonly IBorrowService _service;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerService;
        public BorrowsController(IBorrowService service, IMapper mapper, IBookService bookService, ICustomerService customerService)
        {
            _service = service;
            _mapper = mapper;
            _bookService = bookService;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, int? page)
        {
            var borrows = await _service.GetAll(search);
            var model = _mapper.Map<IEnumerable<GetBorrowModel>>(borrows);
            return View(model.ToPagedList(page ?? 1,5));
        }

        [HttpGet]
        [Route("Borrows/Create")]
        public async Task<IActionResult> Create(string search, string searchCustomer, string searchBorrow)
        {
            var borrows = await _service.GetAll(searchBorrow);
            var bookIds = borrows.Select(x => x.BookId).ToList();
            var bookList = await _bookService.GetAll(search);
            var hehe = bookList.Where(x => !bookIds.Contains(x.Id)).ToList();
            var customerList = await _customerService.GetAll(searchCustomer);
            ViewBag.BookList = new SelectList(hehe, "Id", "Title");
            ViewBag.CustomerList = new SelectList(customerList, "Id", "Email");
            return View(new CreateBorrowModel());
        }

        [HttpPost]
        public IActionResult Create(CreateBorrowModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var borrow = _mapper.Map<CreateBorrowDto>(model);
                _service.Create(borrow);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Borrows/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var borrow = await _service.GetById(id);
            if(borrow == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<UpdateBorrowModel>(borrow);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBorrowModel model)
        {
            if (ModelState.IsValid)
            {
                var borrow = _mapper.Map<UpdateBorrowDto>(model);
                _service.Update(borrow);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Borrows/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var borrow = await _service.GetById(id);
            if(borrow == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<GetBorrowModel>(borrow);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _service.Delete(id);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SendAlert(string emailTo)
        {
            if (emailTo != null)
            {
                var message = "Your return date for the book was expired please return book ASAP!";
                _customerService.SendEmail(emailTo, message);
            }
            return RedirectToAction("Index");
        }
    }
}
