using EcommerceApp.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IUserService
  {
    public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);
    public Task<UserDto> Authenticate(string username, string password);
    public Task<UserDto> GetUser(ClaimsPrincipal user);
    public Task SignOut();
  }
}
