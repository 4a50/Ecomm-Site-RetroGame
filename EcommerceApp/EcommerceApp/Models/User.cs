using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class User
  {
    [Required]
    public string Id { get; set; }
    [Required]
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
  }
}
