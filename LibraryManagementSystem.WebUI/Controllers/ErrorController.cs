using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("/error/404")]
        public IActionResult NotFoundPage()
        {
            return View();
        }

        [HttpGet]
        [Route("/error/403")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
