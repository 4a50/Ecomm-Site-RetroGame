using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Dto
{
  public class LoginData
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
  }
}
