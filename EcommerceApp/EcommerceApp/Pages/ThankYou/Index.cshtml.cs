using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.ThankYou
{
    public class IndexModel : PageModel
    {
      private IOrder order;
      private IUserService userService;
    private ICart cart;
      public UserDto UserInfo { get; set; }
      public Order Order { get; set; }
    public Cart Cart { get; set; }
      public IndexModel(IOrder ord, IUserService user, ICart crt)
      {
        order = ord;
        userService = user;
      cart = crt;
      }
      public async Task OnGet()
      {
      //Retrieves the information needed.
        UserInfo = await userService.GetUser(this.User);
        Order = await order.GetCurrentOrder(UserInfo.Id);
        Cart = await cart.GetCartWithId(UserInfo.Id);
      //Set the Order and the Carts to Inactive
      Order.IsActive = false;
      Order.PaymentComplete = true;
      Cart.CartActive = false;
      await order.UpdateOrder(Order);
      await cart.UpdateCart(Cart);
      //Create New Order and Cart for user.
      Order = await order.CreateNewOrder(UserInfo.Id);
      Cart = await cart.CreateCart(UserInfo.Id, Order.Id);


      }
    }
}
