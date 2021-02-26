using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Services.Email.Interfaces;
using EcommerceApp.Models.Services.Email.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.OrderView
{
    public class IndexModel : PageModel
    {
    private IUserService userService;
    private ICart cart;
    private IOrder order;
    public  IEmail email;
    [BindProperty]
    public UserDto UserInfo { get; set; }    
    [BindProperty]
    public Order Order { get; set; }

    public IndexModel(ICart crt, IUserService user, IOrder ord, IEmail eml)
    {
      userService = user;
      order = ord;
      cart = crt;
      email = eml;
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
      //placeholder to send to the User's email.
      //TODO: Implement actual email address
      Debug.WriteLine(Order.UserId);
      UserDto userStuff = await userService.GetUser(this.User);      
      ///

      Message msg = new Message()
      {
        To = "krystianfrancuz@gmail.com",
        Body = "This is a test from your friendly ECommSite.",
        Subject = "The greatest email ever. :D"
      };
      var response = await email.SendEmailAsync(msg);
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
