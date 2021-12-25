using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Authors;
using LibraryManagementSystem.Application.Services.Authors;
using LibraryManagementSystem.Application.Services.Books;
using LibraryManagementSystem.Shared.Models.Authors;
using LibraryManagementSystem.Shared.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace LibraryManagementSystem.WebUI.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public AuthorsController(IAuthorService service, IMapper mapper, IBookService bookService)
        {
            _service = service;
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, int? page)
        {
            var authors = await _service.GetAll(search);
            var model = _mapper.Map<IEnumerable<GetAuthorModel>>(authors);
            return View(model.ToPagedList(page ?? 1,5));
        }

        [HttpGet]
        [Route("Authors/Create")]
        public IActionResult Create()
        {
            return View(new CreateAuthorModel());
        }

        [HttpGet]
        [Route("Authors/Details/{authorId}")]
        public async Task<IActionResult> Details(int authorId, int? page, string search)
        {
            var author = await _service.GetById(authorId);
            if(author == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var booksByAuthor = await _bookService.GetBooksByAuthor(authorId, search);
            var model = new DetailsModel
            {
                Author = _mapper.Map<GetAuthorModel>(author),
                Books = _mapper.Map<IEnumerable<GetBookModel>>(booksByAuthor).ToPagedList(page ?? 1,5)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var author = _mapper.Map<CreateAuthorDto>(model);
                _service.Create(author);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Authors/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _service.GetById(id);
            if(author == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<UpdateAuthorModel>(author);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<UpdateAuthorDto>(model);
                _service.Update(author);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Authors/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _service.GetById(id);
            if(author == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<GetAuthorModel>(author);
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
