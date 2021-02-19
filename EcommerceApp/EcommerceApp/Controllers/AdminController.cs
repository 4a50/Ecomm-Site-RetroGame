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
    public async Task<IActionResult> AddGame(AdminVm adminvm) 
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
      Game saveGame = await _game.CreateGame(game);
     
      await _game.CreateGenreGame(saveGame.Id, adminvm.Genre.Id);
      

      return Content("Game Added");
    }
    [HttpPost]
    public async Task<IActionResult> AddGenre(AdminVm adminvm)
    {
      if (!ModelState.IsValid)
      {
        return View(adminvm);
      }
      Genre genre = new Genre
      {
        GenreName = adminvm.Genre.GenreName
        
      };
      await _genre.CreateGenre(genre);

      return Content("Genre Added");
    }
    [HttpPost]
    public IActionResult ShowMeTheIdOfGenre (AdminVm adminvm)
    {
      
      return Content(adminvm.Genre.Id.ToString());
    }
  }
}
