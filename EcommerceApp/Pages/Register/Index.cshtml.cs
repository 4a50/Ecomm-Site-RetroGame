using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Services.Email.Interfaces;
using EcommerceApp.Models.Services.Email.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Pages.Register
{
  public class IndexModel : PageModel
  {
    private IUserService UserService;
    private IEmail email;
    public IndexModel(IUserService service, IEmail eml)
    {
      UserService = service;
      email = eml;


    }
    [BindProperty]
    public RegisterUser RegisterUser { get; set; }

    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostAsync()
    {
      RegisterUser.Roles = new List<string>();

      var user = await UserService.Register(RegisterUser, ModelState);
      if (ModelState.IsValid)
      {
        ///
         //Register Email.
        Message registerMsg = new Message()
        {
          To = user.Email,
          Subject = $"{user.Username}, You are registered",
          Body = RegisterEmail(user.Username)
        };
      var resp = await email.SendEmailAsync(registerMsg);
        if (resp.WasSent == false)
        {
          return Redirect("/Login?retry=y");   
          
        }
        ///
        return Redirect("/Login");
      }
      return Redirect("/Register");
    }
  public string RegisterEmail(string username)
  {
    StringBuilder s = new StringBuilder();
    s.Append($"<p>Hello {username}!  We wanted to thank you for registering with us.  You can now log in and add items for purchase.  We hope you will enjoy");
    s.Append($" the wide selection we have available for purchase!  Please let us know if there is anything we can do to assist!</p>");
    s.Append($"<p>Keep On Gaming!</p>");
    s.Append($"<p>The <strong>Get This Proj Done Team</strong></p>");
    return s.ToString();
  }
  }
}
