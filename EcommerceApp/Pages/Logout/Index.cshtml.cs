using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Logout
{
  public class IndexModel : PageModel
  {
    private IUserService UserService;

    public IndexModel(IUserService service)
    {
      UserService = service;
    }
    public async Task OnGet()
    {
      await UserService.SignOut();
    }
  }
}
