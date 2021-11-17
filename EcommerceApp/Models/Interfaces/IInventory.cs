using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IInventory
  {
    Task<GameInv> CreateGame(GameInv game);    
    Task<List<GameInv>> ReadAllGames();
    Task<GameInv> ReadGame(int id);    
    Task<GameInv> UpdateGame(int id, GameInv game);
    Task<GameInv> DeleteGame(int id);
    void DeleteAllGames();
  }
}
