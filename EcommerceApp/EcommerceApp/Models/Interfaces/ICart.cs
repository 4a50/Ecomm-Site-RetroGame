using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface ICart
  {
    Task<Cart> AddGameToCart(string userid, string gameid);
    Task<List<Cart>> GetCart(string id);        
    Task RemoveFromCart(string id);
  }
}
