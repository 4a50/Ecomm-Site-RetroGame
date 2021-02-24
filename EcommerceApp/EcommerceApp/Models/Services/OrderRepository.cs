using EcommerceApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class OrderRepository : IOrder
  {
    public Task<Order> AddOrder(Order order)
    {
      throw new NotImplementedException();
    }

    public Task<Order> GetOrder(int id)
    {
      throw new NotImplementedException();
    }

    public Task<Order> RemoveOrder(int Id)
    {
      throw new NotImplementedException();
    }

    public Task<Order> UpdateOrder(Order order)
    {
      throw new NotImplementedException();
    }
  }
}
