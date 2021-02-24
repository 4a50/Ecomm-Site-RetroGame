using EcommerceApp.Data;
using EcommerceApp.Models.Dto;
using EcommerceApp.Models.Interfaces;
using EcommerceApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class CartRepository : ICart
  {


    private EcommDBContext _context;
    public CartRepository(EcommDBContext context)
    {
      _context = context;
    }

    public Task<Cart> AddToCart(Game game)
    {
      throw new NotImplementedException();
    }

    public async Task<Cart> CreateCart(Cart cart)
    {      
      _context.Entry(cart).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return cart;
    }
    public async Task<Cart> AddGameToCart(string userid, string gameid)
    {
      try
      {
        Cart cart = new Cart
        {
          UserId = userid,
          GameId = gameid.ToString()
        };

        _context.Entry(cart).State = EntityState.Added;
        await _context.SaveChangesAsync();
      return cart;
      }
      catch
      {
        return null;
      }
    }


    public async Task<List<Cart>> GetCart(string id)
    {
      return await _context.Cart
        .Where(q => q.UserId == id)
        .ToListAsync();
    }

    public Task RemoveFromCart(string id)
    {
      throw new NotImplementedException();
    }
  }
}
