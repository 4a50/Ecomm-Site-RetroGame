using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<ApplicationUser> UserManager;
    private SignInManager<ApplicationUser> SignInManager;

    public IdentityUserService(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager)
    {
      UserManager = manager;
      SignInManager = signInManager;
    }
    public async Task<UserDto> Authenticate(string username, string password)
    {
      var result = await SignInManager.PasswordSignInAsync(username, password, true, false);
      if (result.Succeeded)
      {
        var user = await UserManager.FindByNameAsync(username);
        return new UserDto
        {
          Id = user.Id,
          Username = user.UserName,
          Roles = await UserManager.GetRolesAsync(user)
        };
      }
      return null;
    }


    public async Task<UserDto> GetUser(ClaimsPrincipal principal)
    {
      var user = await UserManager.GetUserAsync(principal);
      return new UserDto
      {
        Id = user.Id,
        Username = user.UserName,
        Roles = await UserManager.GetRolesAsync(user)
      };
    }

    public async Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState)
    {
      var user = new ApplicationUser
      {
        UserName = data.Username,
        Email = data.Email
      };
      var result = await UserManager.CreateAsync(user, data.Password);
      if (result.Succeeded)
      {
        await UserManager.AddToRolesAsync(user, data.Roles);
        return new UserDto
        {
          Id = user.Id,
          Username = user.UserName,
          Roles = await UserManager.GetRolesAsync(user)
        };
      }
        return null;
    }

  }
}
