using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
  public class LoginController : Controller
  {
    private IUserService userService;

    public LoginController (IUserService service)
    {
      userService = service;
    }
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Signup()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Authenticate (LoginData data)
    {
      var user = await userService.Authenticate(data.Username, data.Password);
      if (user == null)
      {
        return Redirect("/Login");
      }
      return Redirect("/Shop");
    }
    [HttpPost]
    public async Task<ActionResult<UserDto>> Register (RegisterUser data)
    {
      data.Roles = new List<string>()
      {
        "guest"
      };

      var user = await userService.Register(data, this.ModelState);

      if (ModelState.IsValid)
      {
        return Redirect("/Login");
      }

      return Redirect("/Register");
    }
    [Authorize]
    public async Task<ActionResult<UserDto>> Profile()
    {
      UserDto user = await userService.GetUser(this.User);
      return View(user);
    }
  }
}
