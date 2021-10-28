using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class CartGame
  {
    //Table Properties
    [Required]
    public int GameId { get; set; }
    [Required]
    public int CartId { get; set; }
    //Navigation Properties
    public GameInv Game { get; set; }
    public Cart Cart { get; set; }

  }
}
