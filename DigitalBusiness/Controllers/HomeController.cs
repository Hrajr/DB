using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigitalBusiness.Models;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DAL;

namespace DigitalBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserLogic _userLogic;

        public HomeController(IUserContext context)
        {
            _userLogic = new UserLogic(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reference()
        {
            return View();
        }

        [Route("TestingPage")]
        public IActionResult TestingPage()
        {            
            string Message1 = User.Identity.Name;
            string Message2 = User.IsInRole("Admin") ? "Admin" : "User";
            ViewData["AAA"] = Message1;
            ViewData["BBB"] = Message2;
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }

        [Route("Profile")]
        [HttpGet]
        public IActionResult Profile()
        {
            var ActiveUser = new UserLogic { UserID = User.Identity.Name };
            var model = new LoginViewModel
            {
                ActiveUser = _userLogic.GetUserInfo(ActiveUser)
            };
            return View("Profile", model);
        }

        [Route("Registration")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegistrationForm([Bind("Username, Password, Firstname, Lastname, Address, Zipcode, Place, Phone, Email")] UserLogic user)
        {
            if (!ModelState.IsValid || !_userLogic.Registration(user))
            { return View("Registration"); }            
            return RedirectToAction("Login", "Session");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
