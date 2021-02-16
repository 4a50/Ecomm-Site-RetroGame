using EcommerceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class CartRepository : ICart
  {
    public Task DeleteGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Cart>> GetAllGames()
    {
      throw new NotImplementedException();
    }

    public Task<Cart> GetGame(int id)
    {
      throw new NotImplementedException();
    }

    public Task<Cart> PostGame(Game game)
    {
      throw new NotImplementedException();
    }

    public Task<Cart> UpdateGame(int id, Game game)
    {
      throw new NotImplementedException();
    }
  }
}
