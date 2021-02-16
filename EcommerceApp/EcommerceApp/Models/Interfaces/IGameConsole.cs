using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IGameConsole
  {
    Task<System> PostGame(System system);
    Task<System> GetGame(int id);
    Task<List<System>> GetAllGames();
    Task<System> UpdateGame(int id, System system);
    Task DeleteGame(int id);
  }
}
