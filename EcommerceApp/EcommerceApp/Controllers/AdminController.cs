using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
  public class AdminController : Controller
  {
    private readonly IGenre _genre;
    private readonly IGame _game;
    private IUserService userService;

    public AdminController(IGenre genre, IGame game)
    {
      _genre = genre;
      _game = game;
      //currentGame = new Game();
    }
    [Authorize]
    public async Task<IActionResult> Index(string gmId, string gnId, User user)
    {
      Debug.WriteLine($"Name of CurrentGame: {gmId}");
      Debug.WriteLine($"Name of CurrentGame: {gnId}");
      //Create a list of Genres
      Game game = new Game();
      Genre genre = new Genre();
      if (gmId != "")
      {
        try
        {
          int idNum = int.Parse(gmId);
          game = await _game.GetGame(idNum);
        }
        catch
        {
          Debug.WriteLine("Unable to Parse Value for Record ID");
        }
      }
      if (gnId != "")
      {
        try
        {
          int idNum = int.Parse(gnId);
          genre = await _genre.GetGenre(idNum);
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
        Game = game,
        Genre = genre
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
      List<SelectListItem> genreListBox = new List<SelectListItem>();
      foreach (Genre g in adminVm.GenreList)
      {
        genreListBox.Add(new SelectListItem
        {
          Text = g.GenreName,
          Value = g.Id.ToString()
        });
      }
      adminVm.Genres = genreListBox;
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
      return Redirect("/admin");
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
      int gameId = int.Parse(adminVm.SelectedAnswers.First());
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
    public IActionResult ShowMeTheIdOfGenre(AdminVm adminvm)
    {
      return Content(adminvm.Genre.Id.ToString());
    }
    [HttpPost]
    public async Task<IActionResult> SelectGameToMod(AdminVm adminvm)
    {
      int idNum = int.Parse(adminvm.SelectedAnswers.First());
      Game gDisp = await _game.GetGame(idNum);
      Debug.WriteLine(gDisp.Name);
      return Redirect($"/admin?gmid={idNum}");
    }
    [HttpPost]
    public async Task<IActionResult> SelectGenreToMod(AdminVm adminvm)
    {
      int idNum = int.Parse(adminvm.SelectedAnswers.First());
      Genre gDisp = await _genre.GetGenre(idNum);
      Debug.WriteLine(gDisp.GenreName);
      return Redirect($"/admin?gnId={idNum}");
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
    [HttpPost]
    public async Task<IActionResult> UpdateGenre(AdminVm adminvm)
    {
      await _genre.UpdateGenre(adminvm.Genre.Id, adminvm.Genre);
      Debug.WriteLine("Completed Update");

      return Redirect($"/admin");
    }
    public async Task<IActionResult> AddGenreToGame(AdminVm adminvm)
    {
      if (!ModelState.IsValid)
      {
        return View(adminvm);
      }
      int genreid = adminvm.GenreGame.GenreId;
      int gameid = adminvm.GenreGame.GameId;
      await _game.CreateGenreGame(genreid, gameid);
      return Redirect($"/admin?gmid={gameid}");

    }
    public async Task<IActionResult> RemoveGenreToGame(AdminVm adminvm)
    {
      if (!ModelState.IsValid)
      {
        return View(adminvm);
      }
      int genreid = adminvm.GenreGame.GenreId;
      int gameid = adminvm.GenreGame.GameId;
      await _game.DeleteGenreGame(gameid, genreid);
      return Redirect($"/admin?gmid={gameid}");

    }

  }

}
