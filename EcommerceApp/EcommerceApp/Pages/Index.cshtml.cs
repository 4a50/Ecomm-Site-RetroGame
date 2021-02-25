using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Threading.Tasks;

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
      if (UserInfo == null) { Debug.WriteLine("It's Gonna Break"); }
    }
  }
}
