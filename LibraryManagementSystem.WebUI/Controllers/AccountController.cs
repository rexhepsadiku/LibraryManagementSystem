using AutoMapper;
using LibraryManagementSystem.Application.Services.Authors;
using LibraryManagementSystem.Application.Services.Books;
using LibraryManagementSystem.Application.Services.Customers;
using LibraryManagementSystem.Infrastructure.Identity;
using LibraryManagementSystem.Shared.Models.Accounts;
using LibraryManagementSystem.Shared.Models.Authors;
using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthorService _authorService;
        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IAuthorService authorService, ICustomerService customerService, IBookService bookService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorService = authorService;
            _customerService = customerService;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var roles = await _userManager.IsInRoleAsync(user, "Admin");
                    var role = await _userManager.IsInRoleAsync(user, "SuperAdmin");
                    if (roles || role)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return RedirectToAction("AccessDenied", "Error");
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        public async Task<IActionResult> Profile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var model = new ProfileModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return View(model);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult GetUsers(int? page)
        {
            var model = _userManager.GetUsersInRoleAsync("Admin").Result;
            return View(model.ToPagedList(page ?? 1, 5));
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> UserDetails(string Id, string search, int? page, int? page1, int? page2)
        {
            ViewBag.UserID = Id;
            var model = new UserDetailsModel
            {
                Authors = _mapper.Map<IEnumerable<GetAuthorModel>>(await _authorService.GetAuthorsByUser(Id,search)).ToPagedList(page1 ?? 1,5),
                Customers = _mapper.Map<IEnumerable<GetCustomerModel>>(await _customerService.GetCustomersByUser(Id, search)).ToPagedList(page2 ?? 1,5),
                Books = _mapper.Map<IEnumerable<GetBookModel>>(await _bookService.GetBooksByUser(Id, search)).ToPagedList(page ?? 1,5)
            };
            return View(model);
        }
    }
}
