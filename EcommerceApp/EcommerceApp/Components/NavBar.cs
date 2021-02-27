using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Components.NavBar
{
  public class NavBar : ViewComponent
  {
    private SignInManager<ApplicationUser> SignInManager;
    private UserManager<ApplicationUser> UserManager;    
    [BindProperty]
    public bool IsSignedIn { get; set; }
    public NavBar(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
      SignInManager = signInManager;
      UserManager = userManager;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
      IsSignedIn = SignInManager.IsSignedIn(this.UserClaimsPrincipal);

      return View();
    }
  }
}
