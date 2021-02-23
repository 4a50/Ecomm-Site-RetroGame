using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceApp.Pages.Login
{
  public class IndexModel : PageModel
  {
    private IUserService UserService;
    [BindProperty]
    public LoginData Log { get; set; }
    public IndexModel(IUserService service)
    {
      UserService = service;
    }
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostAsync()
    {

      var user = await UserService.Authenticate(Log.Username, Log.Password);
      if (user == null)
      {
        return Redirect("/Login");
      }
      return Redirect("/Shop");


    }
  }
}
