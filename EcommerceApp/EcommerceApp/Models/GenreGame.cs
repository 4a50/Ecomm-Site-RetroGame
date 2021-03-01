using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class GenreGame
  {
    [Required]
    public int GameId { get; set; }
    [Required]
    public int GenreId { get; set; }
    public Game Game { get; set; }
    public Genre Genre { get; set; }
  }
}
