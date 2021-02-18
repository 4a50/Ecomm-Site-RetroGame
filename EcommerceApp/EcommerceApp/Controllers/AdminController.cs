using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models.Services;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models;

namespace EcommerceApp.Controllers
{
  public class AdminController : Controller
  {
    private readonly IGenre _genre;
    private readonly IGame _game;

    public AdminController (IGenre genre, IGame game)
    {
      _genre = genre;
      _game = game;
    }
    public async Task<IActionResult> IndexAsync()
    {

      //Create a list of Genres
      AdminVm adminVm = new AdminVm
      {
        GenreList = await _genre.GetAllGenres(),
        GameList = await _game.GetAllGames()
      };
      //Pass it in the page
      return View(adminVm);
    }
    [HttpPost]
    public async Task<IActionResult> Add(AdminVm adminvm) 
    {
     if (!ModelState.IsValid)
      {
        return View(adminvm);
      }
      Game game = new Game
      {
        Name = adminvm.Game.Name,
        Description = adminvm.Game.Description,
        ItemPrice = adminvm.Game.ItemPrice,
        GameSystem = adminvm.Game.GameSystem
      };
      await _game.CreateGame(game);

      return Content("Game Added");
    }
  }
}
