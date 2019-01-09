using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Encodings.Web;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        BL.UsersManager bl_usersManager = new BL.UsersManager();

        public IActionResult Index()
        {
            Console.WriteLine(123);

            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("UserName, UserPwd")] LoginViewModel loginViewModel)
        {
            int checkLogin = bl_usersManager.Login(loginViewModel.UserName, loginViewModel.UserPwd);

            if(checkLogin == 0)
            {
                return RedirectToAction("Index", "Home", new {id = loginViewModel.UserName});
            }

            return View();
        }
    }
}