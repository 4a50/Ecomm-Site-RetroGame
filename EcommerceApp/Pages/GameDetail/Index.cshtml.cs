using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.GameDetail
{
  public class IndexModel : PageModel
  {
    private IUserService userService;
    public UserDto UserInfo { get; set; }
    private IGame GameRepository;
    private ICart Cart;
       
    [BindProperty]
    public Game Game { get; set; }
    //[BindProperty]
    //public List<int> Cart { get; set; }
    public IndexModel(IGame game, IUserService service, ICart cart)
    {
      GameRepository = game;
      Cart = cart;
      userService = service;
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
    /// <summary>
    /// Adds Game to the Cart
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> OnPost()
    {
     
      int gameid = Game.Id;      
      UserInfo = await userService.GetUser(this.User);      
      string userid = UserInfo.Id;
      var cart = await Cart.AddGameToCart(userid, gameid);
      if (cart == null)
      {
        Debug.WriteLine("Game Already In Cart");
        return Redirect("/Shop");
      }

      Debug.WriteLine("This was added to the cart: " + cart.GameId);
      return Redirect("/Shop");

    }
  }

}
