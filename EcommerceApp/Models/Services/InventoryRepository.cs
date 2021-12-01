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

    public async Task<InventoryItem> CreateInventoryItem(InventoryItem item)
    {
      _context.Entry(item).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return item;
    }


    public async Task<List<InventoryItem>> ReadAllInventoryItems()
    {
      return await _context.InventoryItem
        //Use the Game Nav Prop in the Model
        .Include(item => item.Game)
        //Only where the gameId matches a record in the game table
        .Where(g => g.Game.Id == g.GameId)
        //Put it all to a list
        .ToListAsync();    
    }

    public async Task<InventoryItem> ReadInventoryItem(int id)
    {
      return await _context.InventoryItem        
        .Include(item => item.Game)
        .Where(g => g.Game.Id == g.GameId)
        .FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<InventoryItem> UpdateGame(int id, InventoryItem item)
    {
      _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return item;
    }        

    public async Task<InventoryItem> DeleteInventoryItem(int id)
    {
      try
      {
        InventoryItem item = await ReadInventoryItem(id);
        _context.Entry(item).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
      return item;
      }
      catch(Exception e)
      {
        return null;
      }
    }
    public void PurgeAllInventoryItems()
    {
     _context.Database.ExecuteSqlRaw("TRUNCATE TABLE INVENTORY");
    }   
  }
}
