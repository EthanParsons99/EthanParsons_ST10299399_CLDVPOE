using Microsoft.AspNetCore.Mvc;
using st10299399POE.Models;
using System.Diagnostics;

namespace st10299399POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int userID)
        {
            List<productTable> products = productTable.GetAllProducts();

            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult AboutUS()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            // Redirect to the signup page
            return RedirectToAction("SignUp", "SignUp");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
