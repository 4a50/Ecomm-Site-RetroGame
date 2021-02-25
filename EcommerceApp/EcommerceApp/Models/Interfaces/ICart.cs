using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface ICart
  {
    Task<CartGame> AddGameToCart(string userid, int gameid);
    Task<Cart> CreateCart(string userId, int orderId);
    Task<List<CartGame>> GetCartGames(int cartId);
    Task<Cart> GetCartWithId(string userid);
    Task RemoveFromCart(string id);
  }
}
