using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Vm;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class AdminService : IAdminService
  {
    private readonly IGenre _genre;
    private readonly IGame _game;
    public AdminService(IGenre genre, IGame game)
    {
      _genre = genre;
      _game = game;
    }

    public async Task<AdminVm> IndexUpdate(string gameId, string genreId)
    {
      // Create a list of Genres
      Game game = new Game();
      Genre genre = new Genre();
      if (gameId != "")
      {
        try
        {
          int idNum = int.Parse(gameId);
          game = await _game.GetGame(idNum);
        }
        catch
        {
          Debug.WriteLine("Unable to Parse Value for Record ID");
        }
      }
      if (genreId != "")
      {
        try
        {
          int idNum = int.Parse(genreId);
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
      return adminVm;
    }
  }
}
