using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.OrderView
{
    public class IndexModel : PageModel
    {
    private IUserService userService;
    private ICart cart;
    private IOrder order;
    [BindProperty]
    public UserDto UserInfo { get; set; }    
    [BindProperty]
    public Order Order { get; set; }

    public IndexModel(ICart crt, IUserService user, IOrder ord)
    {
      userService = user;
      order = ord;
      cart = crt;
    }

    public async Task OnGet()
        {
      UserInfo = await userService.GetUser(this.User);
      Order = await order.GetOrder(UserInfo.Id);
      Debug.WriteLine("123");

        }
    public async Task<IActionResult> OnPost()
    {

      Order.IsActive = true;
      //Process Card Info
      //SendEmails
      //  User
      //  Admin
      //  Warehouse


      await order.UpdateOrder(Order);


      return Redirect("/ThankYou");
    }
    }
}
