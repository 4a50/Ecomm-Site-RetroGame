using System.Collections.Generic;

namespace EcommerceApp.Models
{
  public class Cart
  {    
    public string UserId { get; set; }
    public string GameId { get; set; }    
    public float CartTotal { get; set; }
    
    //Many DBASE Entries for User -> Cart
    //public int QuantityTotal { get; set; }
    //public Order Order { get;set }
    public Game Game { get; set; }
    public List<Game> Games { get; set; }
    public List<Cart> CartList { get; set; }
  }
}
