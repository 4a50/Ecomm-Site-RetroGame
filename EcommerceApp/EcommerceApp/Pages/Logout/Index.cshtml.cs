using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.Logout
{
    public class IndexModel : PageModel
    {
    private IUserService UserService;    
        
    public IndexModel(IUserService service)
    {
      UserService = service;
    }
    public async Task OnGet()    {
      await UserService.SignOut();
    }
  }
}
