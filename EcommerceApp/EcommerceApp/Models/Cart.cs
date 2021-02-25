using System.Collections.Generic;

namespace EcommerceApp.Models
{
  public class Cart
  {
    public int Id { get; set; }
    public bool CartActive { get; set; }
    public string UserId { get; set; } //CK
    public string GameId { get; set; }
    public int OrderId { get; set; } //CK
    public int Quantity { get; set; }
    public float CartTotalPrice { get; set; } //As added or removed increment/decrement
    public List<CartGame> CartGames { get; set; }
  }
}
