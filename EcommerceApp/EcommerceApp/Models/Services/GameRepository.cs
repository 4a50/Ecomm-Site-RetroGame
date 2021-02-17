using EcommerceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class GameRepository : IGame
  {
    public Task DeleteGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Game>> GetAllGames()
    {
      throw new NotImplementedException();
    }

    public Task<Game> GetGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<Game> PostGame(Game game)
    {
      throw new NotImplementedException();
    }

    public Task<Game> UpdateGame(int id, Game game)
    {
      throw new NotImplementedException();
    }
  }
}
