using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages
{
    public class IndexModel : PageModel
    {
    private IUserService userService;
    public UserDto UserInfo { get; set; }

    public IndexModel(IUserService userserv)
    {
      userService = userserv;
    }

      public async Task OnGet()
      {
      UserInfo = await userService.GetUser(this.User);
    }
    }
}
