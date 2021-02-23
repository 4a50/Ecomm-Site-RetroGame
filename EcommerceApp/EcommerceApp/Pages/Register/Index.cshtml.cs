using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.Register
{
  public class IndexModel : PageModel
  {
    private IUserService UserService;
    public IndexModel(IUserService service)
    {
      UserService = service;
    }

    public RegisterUser RegisterUser { get; set; }

    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostAsync()
    {
      RegisterUser.Roles = new List<string>()
              {
                "Guest"
              };
      var user = await UserService.Register(RegisterUser, ModelState);
      if (ModelState.IsValid)
      {
        return Redirect("/Login");
      }
      return Redirect("/Register");
    }
  }
}
