using EcommerceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class GameConsole : IGameConsole
  {
    public Task DeleteGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Models.System>> GetAllGames()
    {
      throw new NotImplementedException();
    }

    public Task<Models.System> GetGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<Models.System> PostGame(Models.System system)
    {
      throw new NotImplementedException();
    }

    public Task<Models.System> UpdateGame(int id, Models.System system)
    {
      throw new NotImplementedException();
    }
  }
}
