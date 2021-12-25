using AutoMapper;
using LibraryManagementSystem.Application.Services.Authors;
using LibraryManagementSystem.Application.Services.Books;
using LibraryManagementSystem.Application.Services.Borrows;
using LibraryManagementSystem.Application.Services.Customers;
using LibraryManagementSystem.Shared.Models.Admin;
using LibraryManagementSystem.Shared.Models.Authors;
using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Borrows;
using LibraryManagementSystem.Shared.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LibraryManagementSystem.WebUI.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IBorrowService _borrowService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public AdminController(IBookService bookService, IAuthorService authorService, 
            IBorrowService borrowService, ICustomerService customerService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _borrowService = borrowService;
            _customerService = customerService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string search, string searchAuthor, string searchCustomer, string searchBorrow)
        {
            var bookList = await _bookService.GetAll(search);
            var authorList = await _authorService.GetAll(searchAuthor);
            var borrowList = await _borrowService.GetAll(searchBorrow);
            var customerList = await _customerService.GetAll(searchCustomer);

            var borrowedBooksCount = borrowList.Select(x => x.BookId).ToList().Count();
            var allBooksCount = bookList.Count();

            ViewBag.BorrowedBooks = borrowedBooksCount;
            ViewBag.AvailableBooks = allBooksCount - borrowedBooksCount;

            var model = new DashboardModel
            {
                Books = _mapper.Map<IEnumerable<GetBookModel>>(bookList),
                Authors = _mapper.Map<IEnumerable<GetAuthorModel>>(authorList),
                Borrows = _mapper.Map<IEnumerable<GetBorrowModel>>(borrowList).ToPagedList(1,5),
                Customers = _mapper.Map<IEnumerable<GetCustomerModel>>(customerList)
            };
            return View(model);
        }
    }
}
