using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.CartView
{
  public class IndexModel : PageModel
  {
    private IUserService userService;
    private ICart cart;
    private IGame game;
    private IOrder order;
    [BindProperty]
    public UserDto UserInfo { get; set; }
    [BindProperty]
    public Cart CartContents { get; set; }
    [BindProperty]
    public List<Game> GamesList { get; set; }
    [BindProperty]
    public Order CustomerOrder { get; set; }


    public IndexModel(ICart cartP, IUserService user, IGame gameI, IOrder ord)
    {
      userService = user;
      cart = cartP;
      game = gameI;
      order = ord;
      GamesList = new List<Game>();
    }

    public async Task OnGet()
    {
      if (this.User.Identity.IsAuthenticated)
      {
        await PopulateProperties();
        //Adds all the games in the cart to a list for display
        foreach (CartGame cartGame in CartContents.CartGames)
        {
          var gameEntry = await game.GetGame(cartGame.GameId);
          GamesList.Add(gameEntry);
        }
        await cart.UpdateCart(CartContents);
      }
      else
      {
        Redirect("/shop");
      }
    }
    public async Task<IActionResult> OnPost()
    {
      //find order with userId
      await PopulateProperties();
      Cart newCart = await cart.GetCartWithId(UserInfo.Id);
      //add in the cart
      Order updateOrder = await order.GetCurrentOrder(UserInfo.Id);
      //update the order
      updateOrder.Cart = newCart;
      //send orderId to orderpage
      await order.UpdateOrder(updateOrder);
      return Redirect("/OrderView");
    }
    private async Task PopulateProperties()
    {
      UserInfo = await userService.GetUser(this.User);
      CartContents = await cart.GetCartWithId(UserInfo.Id);
    }
  }
}
