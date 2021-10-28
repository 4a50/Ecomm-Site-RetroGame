using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class GenreGame
  {
    //Table Properties
    [Required]
    public int GameId { get; set; }
    [Required]
    public int GenreId { get; set; }
    //Navigation Properties
    public GameInv Game { get; set; }
    public Genre Genre { get; set; }
  }
}
