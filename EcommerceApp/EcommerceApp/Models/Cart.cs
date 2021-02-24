using System.Collections.Generic;

namespace EcommerceApp.Models
{
  public class Cart
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public float CartTotal { get; set; }
    public int QuantityTotal { get; set; }

    public List<Game> Games { get; set; }
  }
}
