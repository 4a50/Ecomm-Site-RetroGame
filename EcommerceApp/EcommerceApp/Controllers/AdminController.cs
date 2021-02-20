using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models.Services;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

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
      //currentGame = new Game();
    }
    public async Task<IActionResult> Index(string value )
    {
      Debug.WriteLine($"Name of CurrentGame: {value}");
      //Create a list of Genres
      Game game = new Game();
      if (value != "")
      {
        try
        {
          int idNum = int.Parse(value);
          game = await _game.GetGame(idNum); 
        }
        catch
        {
          Debug.WriteLine("Unable to Parse Value for Record ID");
        }
      }
  
      AdminVm adminVm = new AdminVm
      {
        GenreList = await _genre.GetAllGenres(),
        GameList = await _game.GetAllGames(),
        Game = game
        
        
      };
      List<SelectListItem> listboxList = new List<SelectListItem>();
      foreach (Game g in adminVm.GameList)
      {
        listboxList.Add(
          new SelectListItem
          {
            Text = g.Name,
            Value = g.Id.ToString()
          }
          );      
      }
      adminVm.Games = listboxList;
      //To carry peristance through the Update Game Selection process
      
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

      return Redirect("/admin");
    }
    [HttpPost]
    public async Task<IActionResult> DeleteGame(AdminVm adminVm)
    {
      int gameId;
      try { gameId = int.Parse(adminVm.SelectedAnswer); }
      catch { throw new Exception("Unable to Parse Radio Button Input For Game Select"); }
     await _game.DeleteGame(gameId);
      return Redirect("/admin");
    }
    [HttpPost]
    public async Task<IActionResult> DeleteGenre(AdminVm adminVm)
    {
      int genreId;
      try { genreId = int.Parse(adminVm.SelectedAnswer); }
      catch { throw new Exception("Unable to Parse Radio Button Input For Game Select"); }
      await _genre.DeleteGenre(genreId);
      return Redirect("/admin");
    }
    [HttpPost]
    public IActionResult ShowMeTheIdOfGenre (AdminVm adminvm)
    {      
      return Content(adminvm.Genre.Id.ToString());
    }
    [HttpPost]
    public async Task<IActionResult> SelectGameToMod(AdminVm adminvm)
    {
      int idNum = int.Parse(adminvm.SelectedAnswers.First());
      Game gDisp = await _game.GetGame(idNum);
      Debug.WriteLine(gDisp.Name);
      //currentGame =      
      //  new Game
      //  {
      //    Id = gDisp.Id,
      //    Name = gDisp.Name,
      //    Description = gDisp.Description,
      //    ItemPrice = gDisp.ItemPrice,
      //    GameSystem = gDisp.GameSystem
      //  };

      return Redirect($"/admin?value={idNum}");
    }
    [HttpPost]
    public async Task<IActionResult> UpdateGame(AdminVm adminvm)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"{adminvm.Game.Id} ");
      sb.Append($"{adminvm.Game.Name} ");
      sb.Append($"{adminvm.Game.Description} ");
      sb.Append($"{adminvm.Game.Description} ");
      Debug.WriteLine(sb.ToString());

      await _game.UpdateGame(adminvm.Game.Id, adminvm.Game);
      Debug.WriteLine("Completed Update");

      return Redirect($"/admin");
    }
  }
}
