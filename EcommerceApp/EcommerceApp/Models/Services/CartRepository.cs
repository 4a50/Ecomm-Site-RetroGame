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

    public async Task<Cart> CreateCart(string userId, int orderId)
    {
      Cart cart = new Cart { UserId = userId, OrderId = orderId, CartActive=true };
      _context.Entry(cart).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return cart;
    }
    public async Task<CartGame> AddGameToCart(string userid, int gameid)
    {      
     //I need UserId <-- Got it
     //I need am OrderId (from active Order)
      
      var cart = await _context.Cart
        .Where(q => q.UserId == userid && q.CartActive == true)
        .FirstOrDefaultAsync();
      if (cart == null)
      {
        return null;
      }

      CartGame cartGame = new CartGame
      {
        GameId = gameid,
        CartId = cart.Id
      };
      try
      {
        _context.Entry(cartGame).State = EntityState.Added;
        await _context.SaveChangesAsync();
      return cartGame;
      }
      catch 
      {
        return null;
      }
      
      
    }
 
    public async Task<Cart> GetCartWithId (string userid)
    {
      return await _context.Cart
        .Include(c => c.UserId == userid && c.CartActive == true)
        .FirstOrDefaultAsync();
    }

    public async Task<List<CartGame>> GetCartGames(int cartId)
    {
      return await _context.CartGame
        .Include(g => g.CartId == cartId)
        .ToListAsync();
    }

    public Task RemoveFromCart(string id)
    {
      throw new NotImplementedException();
    }
  }
}
