using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<ApplicationUser> UserManager;
    private SignInManager<ApplicationUser> SignInManager;
    private IOrder Order;
    private ICart Cart;

    public IdentityUserService(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager, IOrder order, ICart cart)
    {
      UserManager = manager;
      SignInManager = signInManager;
      Order = order;
      Cart = cart;
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
      if (user == null) { return null; }
      return new UserDto
      {
        Id = user.Id,
        Username = user.UserName,
        Email = user.Email,
        Roles = await UserManager.GetRolesAsync(user)
      };
    }
    public async Task<UserDto> LookUpUser (string userid)
    {
      ApplicationUser lookupUser = await UserManager.FindByIdAsync(userid);
      
      return new UserDto
      {
        Id = lookupUser.Id,
        Username = lookupUser.UserName,
        Email = lookupUser.Email
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
        data.Roles.Add("Guest");
        await UserManager.AddToRolesAsync(user, data.Roles);

        //Add a new Order to the For the New ID
        var order = await Order.CreateNewOrder(user.Id);
        //Add A new Cart.
        await Cart.CreateCart(user.Id, order.Id);

        return new UserDto
        {
          Id = user.Id,
          Username = user.UserName,
          Roles = await UserManager.GetRolesAsync(user)
        };
      }
      // Modify/Delete this to handle the errors.
      foreach (var error in result.Errors)
      {
        var errorKey =
            error.Code.Contains("Password") ? nameof(data.Password) :
            error.Code.Contains("Email") ? nameof(data.Email) :
            error.Code.Contains("UserName") ? nameof(data.Username) :
            "";
        modelState.AddModelError(errorKey, error.Description);
      }
      return null;
    }
    public async Task SignOut()
    {
      await SignInManager.SignOutAsync();
    }
  }
}

