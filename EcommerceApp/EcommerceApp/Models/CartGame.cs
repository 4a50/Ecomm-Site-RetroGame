using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
  public class CartGame
  {
    public int GameId { get; set; }
    public int CartId { get; set; }
   public Game Game { get; set; }
    public Cart Cart { get; set; }

  }
}
