using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
  public class InventoryItem
  {
    public enum InvType
    {
      Game = 1,
      GameSystem,
      GameSystemComponent,
      GameSystemAcc,
      Food,
      Other

    }
    public enum InvCondition
    {
      Excellent = 1,
      Good,
      Fair,
      Poor
    }
    public enum InvStatus
    {
      Not_Applicable = 1,
      Complete,
      Manual,
      Box,
      Loose
    }
    public int Id { get; set; }
    public int GameId { get; set; }
    public InvType Type { get; set; }
    public InvCondition Condition { get; set; }
    public InvStatus Status { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    // Add Others as they are made
    public Game Game { get; set; }
  }
}
