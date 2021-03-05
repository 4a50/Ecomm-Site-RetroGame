using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Dto
{
  public class RegisterUser
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }
    public List<string> Roles { get; set; }
  }
}
