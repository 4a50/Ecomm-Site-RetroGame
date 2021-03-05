using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class Genre
  {
    //Table Properties
    [Required]
    public int Id { get; set; }
    public string GenreName { get; set; }

  }
}
