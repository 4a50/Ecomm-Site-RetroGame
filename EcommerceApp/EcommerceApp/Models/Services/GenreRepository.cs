using EcommerceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class GenreRepository : IGenre
  {
    public Task DeleteGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Genre>> GetAllGames()
    {
      throw new NotImplementedException();
    }

    public Task<Genre> GetGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<Genre> PostGame(Game game)
    {
      throw new NotImplementedException();
    }

    public Task<Genre> UpdateGame(int id, Game game)
    {
      throw new NotImplementedException();
    }
  }
}
