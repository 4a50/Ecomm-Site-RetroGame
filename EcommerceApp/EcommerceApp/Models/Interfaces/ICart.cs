using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface ICart
  {
    Task<Cart> PostGame(Game game);
    Task<Cart> GetGame(int id);
    Task<List<Cart>> GetAllGames();
    Task<Cart> UpdateGame(int id, Game game);
    Task DeleteGame(int id);
  }
}
