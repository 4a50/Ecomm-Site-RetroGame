using EcommerceApp.Models;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.GameDetail
{
  public class IndexModel : PageModel
  {
    private IGame GameRepository;
    [BindProperty]
    public Game Game { get; set; }
    //[BindProperty]
    //public List<int> Cart { get; set; }
    public IndexModel(IGame game)
    {
      GameRepository = game;
    }
    public async Task OnGetAsync(string id)
    {
      Debug.WriteLine($"ID Passed in: <{id}>");
      if (id != "")
      {
        try
        {
          Game = await GameRepository.GetGame(int.Parse(id));
        }
        catch
        {
          Game = new Game
          {            
            Name = "NoneSelected",
            Description = "NoneSelected",
            ItemPrice = 0,
            ImageUrl = "https://via.placeholder.com/150"
          };
        }
      }
    }
    public IActionResult OnPost()
    {
      Debug.WriteLine("This was added to the cart: " + Game.Id);
      return Redirect("/Shop");
      
    }
  }

}
