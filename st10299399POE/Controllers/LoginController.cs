using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using st10299399POE.Models;

namespace st10299399POE.Controllers
{
    public class LoginController : Controller
    {

        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult LoginForm(string email, string name)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
                HttpContext.Session.SetInt32("UserID", userID);
                return RedirectToAction("MyWork", "Home", new { userID = userID });
            }
            else
            {
                return View("LoginFailed");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
