using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceApp.Pages
{
  public class IndexModel : PageModel
  {
    private IUserService userService;
    private SignInManager<ApplicationUser> signInManager;
    public UserDto UserInfo { get; set; }
    [BindProperty]
    public bool IsSignedIn { get; set; }

    public IndexModel(IUserService userserv, SignInManager<ApplicationUser> signIn)
    {
      userService = userserv;
      signInManager = signIn;
    }
    public async Task OnGet()
    {
      UserInfo = await userService.GetUser(this.User);
      if (UserInfo == null) { Debug.WriteLine("It's Gonna Break"); }
    }
  }
}
