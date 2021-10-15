using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Shared
{
  public class _NavBarModel : PageModel
  {
    private SignInManager<ApplicationUser> SignInManager;
    [BindProperty]
    public bool IsSignedIn { get; set; }
    public _NavBarModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
      SignInManager = signInManager;
    }
    public void OnGetAsync()
    {
      IsSignedIn = SignInManager.IsSignedIn(this.User);
    }
    public async Task OnPost()
    {

      await SignInManager.SignOutAsync();
    }
  }
}
