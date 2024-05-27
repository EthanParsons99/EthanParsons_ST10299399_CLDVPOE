using Microsoft.AspNetCore.Mvc;
using st10299399POE.Models;

namespace st10299399POE.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodtbl = new productTable();

        [HttpPost]
        public ActionResult MyWork(productTable products)
        {
            var result2 = prodtbl.insert_Product(products);
            return RedirectToAction("MyWork", "Home");
        }

        [HttpGet]
        public ActionResult myWork()
        {
            return View(prodtbl);
        }
    }
}
