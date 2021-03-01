using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class Genre
  {
    [Required]
    public int Id { get; set; }
    public string GenreName { get; set; }

  }
}
