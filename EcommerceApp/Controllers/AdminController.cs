using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
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
    /// <summary>
    /// To access the index page user must have the policy of "update" availible to them.
    /// The following Roles are authorized:
    /// Administrator
    /// Editor
    /// </summary>
    /// <param name="gmId"></param>
    /// <param name="gnId"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    [Authorize(Policy = "update")]
    public async Task<IActionResult> Index(string gmId, string gnId, User user)
    {
      var adminVm = await AdminService.IndexUpdate(gmId, gnId);
      return View(adminVm);
    }
    /// <summary>
    /// This will add a game to the database
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddGame(AdminVm adminvm)
    {
      if (!ModelState.IsValid)
      {
        return View(adminvm);
      }
      GameInv game = new GameInv
      {
        Name = adminvm.Game.Name,
        Description = adminvm.Game.Description,
        ItemPrice = adminvm.Game.ItemPrice,
        GameSystem = adminvm.Game.GameSystem
      };
      GameInv saveGame = await _game.CreateGame(game);

      //await _game.CreateGenreGame(saveGame.Id, adminvm.Genre.Id);
      return Redirect("/admin");
    }
    /// <summary>
    /// Adds a Genre Category to the database
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Removes a game from the database
    /// </summary>
    /// <param name="adminVm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> DeleteGame(AdminVm adminVm)
    {
      int gameId = int.Parse(adminVm.SelectedAnswers.First());
      await _game.DeleteGame(gameId);
      return Redirect("/admin");
    }
    /// <summary>
    /// Deletes a Genre from the database
    /// </summary>
    /// <param name="adminVm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> DeleteGenre(AdminVm adminVm)
    {
      int genreId;
      try { genreId = int.Parse(adminVm.SelectedAnswer); }
      catch { throw new Exception("Unable to Parse Radio Button Input For Game Select"); }
      await _genre.DeleteGenre(genreId);
      return Redirect("/admin");
    }
    /// <summary>
    /// Assists with the dropdown menu for selecting a Genre for use
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult ShowMeTheIdOfGenre(AdminVm adminvm)
    {
      return Content(adminvm.Genre.Id.ToString());
    }
    /// <summary>
    /// Works with the ListBox to send the selected Id Number as a quesry string on Redirect to populate the fields for edit.
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SelectGameToMod(AdminVm adminvm)
    {
      int idNum = int.Parse(adminvm.SelectedAnswers.First());
      GameInv gDisp = await _game.GetGame(idNum);
      Debug.WriteLine(gDisp.Name);
      return Redirect($"/admin?gmid={idNum}");
    }
    /// <summary>
    /// Works with the Genre ListBox to send the selected Id number as a query string on the redirect.
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SelectGenreToMod(AdminVm adminvm)
    {
      int idNum = int.Parse(adminvm.SelectedAnswers.First());
      Genre gDisp = await _genre.GetGenre(idNum);
      Debug.WriteLine(gDisp.GenreName);
      return Redirect($"/admin?gnId={idNum}");
    }
    /// <summary>
    /// Performs the database action to update selected game in the database
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UpdateGame(AdminVm adminvm)
    {
      await _game.UpdateGame((int)adminvm.Game.Id, adminvm.Game);
      return Redirect($"/admin");
    }
    /// <summary>
    /// Performs the database action to update the selected genre in the database.
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UpdateGenre(AdminVm adminvm)
    {
      await _genre.UpdateGenre(adminvm.Genre.Id, adminvm.Genre);
      return Redirect($"/admin");
    }
    /// <summary>
    /// Creates a new entry in the GenreGame join table.  One game may be attached to more than one genre
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Removes a genre attached to a game.  Deletes an entry in the GenreGame join table
    /// </summary>
    /// <param name="adminvm"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Performs upload actions to send a file to the Azure Blob, updates the returning URL to the selected game.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="admin"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file, AdminVm admin)
    {
      Debug.WriteLine(admin.SelectedAnswer);
      var fileUp = await UploadService.Upload(file);
      GameInv getGame = await _game.GetGame(int.Parse(admin.SelectedAnswer));
      getGame.ImageUrl = fileUp.Url;
      await _game.UpdateGame(int.Parse(admin.SelectedAnswer), getGame);



      return Redirect("/admin");
    }

  }

}
