using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
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
    
    public async Task<Cart> CreateCart(string userId, int orderId)
    {
      Cart cart = new Cart { UserId = userId, OrderId = orderId, CartActive = true };
      _context.Entry(cart).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return cart;
    }
    public async Task<CartGame> AddGameToCart(string userid, int gameid)
    {
      var cart = await _context.Cart
        .Where(q => q.UserId == userid && q.CartActive == true)
        .FirstOrDefaultAsync();
      var game = await _context.Game
        .Where(q => q.Id == gameid)
        .FirstOrDefaultAsync();
      
      if (cart == null) return null;

      CartGame cartGame = new CartGame
      {
        GameId = gameid,
        CartId = cart.Id
      };
      try
      {
        //Add to the CartGame Join Table
        _context.Entry(cartGame).State = EntityState.Added;
        await _context.SaveChangesAsync();

        //Add to the total price and Qty of the Cart and Update
        cart.CartTotalPrice += game.ItemPrice;
        cart.Quantity += 1;
        _context.Entry(cart).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return cartGame;
      }
      
      catch { return null; }
    }

    public async Task<Cart> GetCartWithId(string userid)
    {
      var cart = await _context.Cart
        .Where(c => c.UserId == userid && c.CartActive == true)  
        .Include(g => g.CartGames)
        .ThenInclude(ga => ga.Game)
        .FirstOrDefaultAsync();
      cart.CartGames = await GetCartGames(cart.Id);
      return cart;
    }

    public async Task<List<CartGame>> GetCartGames(int cartId)
    {
      return await _context.CartGame
        .Where(g => g.CartId == cartId)
        .ToListAsync();
    }

    public Task RemoveFromCart(string id)
    {
      throw new NotImplementedException();
    }

    public async Task UpdateCart(Cart cart)
    {
      
      _context.Entry(cart).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}
