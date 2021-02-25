using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    private readonly IUploadService UploadService;
    private readonly IAdminService AdminService;

    public AdminController(IGenre genre, IGame game, IUploadService uploadService, IAdminService adminService)
    {
      _genre = genre;
      _game = game;
      UploadService = uploadService;
      AdminService = adminService;

      
    }
    [Authorize(Policy = "update")]
    public async Task<IActionResult> Index(string gmId, string gnId, User user)
    {
      var adminVm = await AdminService.IndexUpdate(gmId, gnId);
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

      //await _game.CreateGenreGame(saveGame.Id, adminvm.Genre.Id);
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
      await _game.UpdateGame(adminvm.Game.Id, adminvm.Game);
      return Redirect($"/admin");
    }
    [HttpPost]
    public async Task<IActionResult> UpdateGenre(AdminVm adminvm)
    {
      await _genre.UpdateGenre(adminvm.Genre.Id, adminvm.Genre);
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
      try
      {
        await _game.CreateGenreGame(genreid, gameid);
      }
      catch
      {
        Debug.WriteLine("Conflict with Database Occured. Multiple Values?");
      }
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
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file, AdminVm admin)
    {
      Debug.WriteLine(admin.SelectedAnswer);           
     var fileUp = await UploadService.Upload(file);
      Game getGame = await _game.GetGame(int.Parse(admin.SelectedAnswer));
      getGame.ImageUrl = fileUp.Url;
      await _game.UpdateGame(int.Parse(admin.SelectedAnswer), getGame);



      return Redirect("/admin");
    }

  }

}
