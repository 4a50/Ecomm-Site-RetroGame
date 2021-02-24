using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface ICart
  {
    Task<Cart> AddToCart(Game game);
    Task<Cart> GetCart(string id);        
    Task RemoveFromCart(string id);
  }
}
