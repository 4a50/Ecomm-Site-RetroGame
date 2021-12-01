using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IInventory
  {
    Task<InventoryItem> CreateInventoryItem(InventoryItem item);    
    Task<List<InventoryItem>> ReadAllInventoryItems();
    Task<InventoryItem> ReadInventoryItem(int id);    
    Task<InventoryItem> UpdateGame(int id, InventoryItem item);
    Task<InventoryItem> DeleteInventoryItem(int id);
    void PurgeAllInventoryItems();
  }
}
