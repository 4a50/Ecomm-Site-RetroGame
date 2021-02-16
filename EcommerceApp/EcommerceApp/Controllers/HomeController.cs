using EcommerceApp.Models;
using EcommerceApp.Models.Vm;
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
      User user = new User
      {
        FirstName = "Bob's",
        LastName = "You're Uncle"

      };
          return View(user);
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
      List<ShopVm> shopVms = new List<ShopVm>{
        new ShopVm
      {
        GenreGame = new GenreGame { Genre = new Genre {GenreName = "Adventure" } },
        SystemGame = new SystemGame { System = new Models.System {SystemName = "Super Nintendo" } },
      },
        new ShopVm
      {
        GenreGame = new GenreGame { Genre = new Genre {GenreName = "RPG" } },
        SystemGame = new SystemGame { System = new Models.System {SystemName = "Genesis" } },
      } };
        return View(shopVms);
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
      User user = new User
      {
        FirstName = "Luigi",
        LastName = "Mario",
        Password = "Mar!0SuckS"
      };
            return View(user);
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
      ShopVm shopVm = new ShopVm
      {
        Game = new Game
        {
          Name = "Super Metroid",
          Description = "Samus Kicks some ass",
          ItemPrice = 75.00f,
          GenreGame = new GenreGame
          {
            Genre = new Genre
            {
              GenreName = "Awesome"
            }            
          },
          SystemGame = new SystemGame { System = new Models.System 
          { SystemName = "Super Nintendo" } 
          }
        }
      };

            return View(shopVm);
        }









    }
}
