using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Game()
        {
            Game yoshi = new Game()
            {
                Name = "Yoshi's Island",

            };
            return View(yoshi);
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult CategoryDetail()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult GameDetail()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Receipt()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }









    }
}
