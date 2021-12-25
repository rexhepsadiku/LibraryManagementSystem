using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Books;
using LibraryManagementSystem.Application.Services.Authors;
using LibraryManagementSystem.Application.Services.Books;
using LibraryManagementSystem.Application.Services.Borrows;
using LibraryManagementSystem.Shared.Models.Books;
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
    public class BooksController : Controller
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly IBorrowService _borrowService;
        public BooksController(IBookService service, IMapper mapper, IAuthorService authorService, IBorrowService borrowService)
        {
            _service = service;
            _mapper = mapper;
            _authorService = authorService;
            _borrowService = borrowService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, int? page, string searchBorrow)
        {
            var borrows = await _borrowService.GetAll(searchBorrow);
            ViewBag.BookIds = borrows.Select(x => x.BookId).ToList();
            var books = await _service.GetAll(search);
            var model = _mapper.Map<IEnumerable<GetBookModel>>(books);
            return View(model.ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        [Route("Books/Create")]
        public async Task<IActionResult> Create(string searchAuthor)
        {
            var authorList = await _authorService.GetAll(searchAuthor);
            ViewBag.AuthorList = new SelectList(authorList, "Id", "FirstName");
            return View(new CreateBookModel());
        }

        [HttpPost]
        public IActionResult Create(CreateBookModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var book = _mapper.Map<CreateBookDto>(model);
                _service.Create(book);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Books/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _service.GetById(id);
            if(book == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<UpdateBookModel>(book);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<UpdateBookDto>(model);
                _service.Update(book);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Books/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _service.GetById(id);
            if(book == null)
            {
                return RedirectToAction("NotFoundPage", "Error");
            }
            var model = _mapper.Map<GetBookModel>(book);
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
