using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Shop
{
  public class IndexModel : PageModel
  {
    private readonly IGame Game;
    [BindProperty]
    public List<Game> Games { get; set; }
    public IndexModel(IGame game)
    {
      Game = game;
    }
    public async Task OnGet()
    {
      Games = await Game.GetAllGames();
    }
    public void OnPost()
    {
    }
  }
}
