using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Shop
{
  public class IndexModel : PageModel
  {
    private readonly IGame Game;
    private readonly IGenre Genre;
    [BindProperty]
    public List<Game> Games { get; set; }
    [BindProperty]
    public List<Genre> Genres { get; set; }
    [BindProperty]      
    public string SelectAnswer {get;set;}

    public IndexModel(IGame game, IGenre genre)
    {
      Game = game;
      Genre = genre;
    }
    public async Task OnGet(string id)
    {
      Genres = await Genre.GetAllGenres();

      bool canParse = int.TryParse(id, out int intGenreId);
      if (id == "0" || !canParse)
      {
        Games = await Game.GetAllGames();
      }
      else
      {
        try
        {
          Games = await Game.GetGamesByGenre(intGenreId);   
        }
        catch { Games = await Game.GetAllGames(); }
      }

    }
    public IActionResult OnPost()
    {
      return Redirect($"/Shop?id={SelectAnswer}");
    }
  }
}
