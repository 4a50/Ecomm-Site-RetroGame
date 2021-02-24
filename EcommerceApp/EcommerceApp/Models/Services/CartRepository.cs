using EcommerceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class CartRepository : ICart
  {
    public Task<Cart> AddToCart(Game game)
    {
      throw new NotImplementedException();
    }

    public Task<Cart> GetCart(string id)
    {
      throw new NotImplementedException();
    }

    public Task RemoveFromCart(string id)
    {
      throw new NotImplementedException();
    }
  }
}
