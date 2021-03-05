using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class Game
  {
    //Table Properties
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public float ItemPrice { get; set; }
    public string GameSystem { get; set; }
    public string ImageUrl { get; set; }
    //Navigation Properties
    public List<GenreGame> GenreGames { get; set; }
  }
}
