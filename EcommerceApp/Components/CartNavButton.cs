using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Components
{
  /// <summary>
  /// Handles The Updates and Directs to the cart page
  /// </summary>
  [ViewComponent]
  public class CartNavButton : ViewComponent
  {
    private ICart Cart;
    private IUserService userService;
    public UserDto UserInfo { get; set; }
    public Cart CartItems { get; set; }

    public CartNavButton(IUserService userserv, ICart cart)
    {
      userService = userserv;
      Cart = cart;
    }
    /// <summary>
    /// When called this method will run.
    /// </summary>
    /// <returns></returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
      
        UserInfo = await userService.GetUser(this.UserClaimsPrincipal);
      if (UserInfo != null)
      {
        CartItems = await Cart.GetCartWithId(UserInfo.Id);
      }else 
      {
        CartItems = new Cart { CartGames = new List<CartGame> ()};      
      }
      return View(CartItems);
    }
    

  }
}
