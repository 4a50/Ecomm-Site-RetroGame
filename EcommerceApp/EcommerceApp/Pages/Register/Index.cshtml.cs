using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Register
{
  public class IndexModel : PageModel
  {
    private IUserService UserService;
    public IndexModel(IUserService service)
    {
      UserService = service;
    }
    [BindProperty]
    public RegisterUser RegisterUser { get; set; }

    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostAsync()
    {
      RegisterUser.Roles = new List<string>()
              {
                "Administrator"
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
