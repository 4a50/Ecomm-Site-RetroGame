using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
  public class Cart
  {
    // Table Properties
    [Required]
    public int Id { get; set; }
    public bool CartActive { get; set; }
    [Required]
    public string UserId { get; set; } //CK
    public string GameId { get; set; }
    [Required]
    public int OrderId { get; set; } //CK
    public int Quantity { get; set; }
    public float CartTotalPrice { get; set; } //As added or removed increment/decrement
    //Navigation Property
    public List<CartGame> CartGames { get; set; }
  }
}
