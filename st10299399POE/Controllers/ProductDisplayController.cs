using Microsoft.AspNetCore.Mvc;
using st10299399POE.Models;

namespace st10299399POE.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
