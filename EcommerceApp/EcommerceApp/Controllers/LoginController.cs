using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;

        public LoginController(IUserService service)
        {
            userService = service;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Signup()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Authenticate(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user == null)
            {
                return Redirect("/Home/Login");
            }
            return Redirect("/Home/Shop");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterUser data)
        {
            data.Roles = new List<string>()
              {
                "Administrator"
              };

            var user = await userService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return Redirect("/Home/Login");
            }

            return Redirect("/Home/Register");
        }
        [Authorize]
        public async Task<ActionResult<UserDto>> Profile()
        {
            UserDto user = await userService.GetUser(this.User);
            return View(user);
        }
    }
}
