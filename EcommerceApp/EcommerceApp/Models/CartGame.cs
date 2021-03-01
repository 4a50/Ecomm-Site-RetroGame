using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class CartGame
  {
    [Required]
    public int GameId { get; set; }
    [Required]
    public int CartId { get; set; }
    public Game Game { get; set; }
    public Cart Cart { get; set; }

  }
}
