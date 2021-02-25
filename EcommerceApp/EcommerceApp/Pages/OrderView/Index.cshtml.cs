using System;
using System.Collections.Generic;
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
    public UserDto UserInfo { get; set; }    
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
        }
    }
}
