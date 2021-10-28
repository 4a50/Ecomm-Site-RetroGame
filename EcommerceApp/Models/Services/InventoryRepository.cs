using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class InventoryRepository : IInventory
  {
    private EcommDBContext _context;

    public InventoryRepository(EcommDBContext context)
    {
      _context = context;
    }

    public async Task<GameInv> CreateGame(GameInv game)
    {
      _context.Entry(game).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return game;
    }


    public async Task<List<GameInv>> ReadAllGames()
    {
      return await _context.GameInventory.ToListAsync();    
    }

    public async Task<GameInv> ReadGame(int id)
    {
      return await _context.GameInventory.FirstOrDefaultAsync();
    }

    public async Task<GameInv> UpdateGame(int id, GameInv game)
    {
      _context.Entry(game).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return game;
    }        
    public void  DeleteAllGames()
    {
      _context.Database.ExecuteSqlRaw("TRUNCATE TABLE INVENTORY");
    }   

    public async Task<GameInv> DeleteGame(int id)
    {
      try
      {
        GameInv game = await ReadGame(id);
        _context.Entry(game).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
      return game;
      }
      catch(Exception e)
      {
        return null;
      }
    }
  }
}
