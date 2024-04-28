﻿using Microsoft.AspNetCore.Mvc;
using st10299399POE.Models;

namespace st10299399POE.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult About(userTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }
    }
}
