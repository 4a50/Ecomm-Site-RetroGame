using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Components
{
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
