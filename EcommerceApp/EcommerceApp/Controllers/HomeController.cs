﻿using EcommerceApp.Models;
using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            User user = new User
            {
                FirstName = "Bob's",
                LastName = "You're Uncle"

            };
            return View(user);
        }
        [Authorize]
        public IActionResult Game()
        {
            Game yoshi = new Game()
            {
                Name = "Yoshi's Island",

            };
            return View(yoshi);
        }
        [Authorize]
        public IActionResult Cart()
        {

            Cart cart = new Cart
            {
                CartTotal = 2,
                Quantity = 2,
                QuantityTotal = 2,
                Games = new List<Game> {
          new Game { Name = "Kirby's Dreamland", ItemPrice = 30.00f},
          new Game {Name = "Chrono Trigger", ItemPrice = 100.00f}
        }
            };
            return View(cart);
        }
        [Authorize]
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
        [Authorize]
        public IActionResult Checkout()
        {
            CheckoutVm checkout = new CheckoutVm
            {
                Cart = new Cart
                {
                    CartTotal = 2,
                    Quantity = 2,
                    QuantityTotal = 2,
                    Games = new List<Game> {
          new Game { Name = "Kirby's Dreamland", ItemPrice = 30.00f},
          new Game {Name = "Chrono Trigger", ItemPrice = 100.00f}
        }
                },
                User = new User { FirstName = "Samus", LastName = "Aran" }
            };
            return View(checkout);
        }
        [Authorize]
        public IActionResult GameDetail()
        {

            Game game = new Game
            {
                Name = "Starfox",
                Description = "The mostest badass game with the FX Chip!",
                GenreGame = new GenreGame
                {
                    Genre = new Genre { GenreName = "Space Simulator" }
                },
                SystemGame = new SystemGame
                {
                    System = new Models.System { SystemName = "Super Nintendo" }
                }
            };
            return View(game);
        }
        [AllowAnonymous]
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
        [Authorize]
        public IActionResult Receipt()
        {
            User user = new User
            {
                FirstName = "Link",
                LastName = "Of Hyrule",
                Email = "Link@hyrule.wrld"
            };
            return View(user);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize]
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
                    SystemGame = new SystemGame
                    {
                        System = new Models.System
                        { SystemName = "Super Nintendo" }
                    }
                }
            };

            return View(shopVm);
        }
        [Authorize(Policy = "update")]
        public IActionResult AdminDash()
        {
            return View();
        }
    }
}
