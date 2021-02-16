using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IGenre
  {
    Task<Genre> PostGame(Game game);
    Task<Genre> GetGame(int id);
    Task<List<Genre>> GetAllGames();
    Task<Genre> UpdateGame(int id, Game game);
    Task DeleteGame(int id);
  }
}
