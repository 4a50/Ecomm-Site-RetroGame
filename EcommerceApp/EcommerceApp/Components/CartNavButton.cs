using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

      var cartList = await Cart.GetCart(UserInfo.Id);
      Debug.WriteLine($"cartList: {cartList.Count}");
      Cart cart = new Cart
      {
        CartList = cartList      
      };
     

      //Debug.WriteLine($"{cartList}");
      //CartItems.CartList = await Cart.GetCart(UserInfo.Id);      
      return View(cart);
    }

  }
}
