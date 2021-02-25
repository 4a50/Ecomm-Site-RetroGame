using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models.Services
{
  public class OrderRepository : IOrder
  {
    private EcommDBContext _context;
    public OrderRepository(EcommDBContext context)
    {
      _context = context;
    }
    public Task<Order> AddOrder(Order order)
    {
      throw new NotImplementedException();
    }
    public async Task<Order> CreateNewOrder(string userid)
    {
      Order order = new Order
      {
        UserId = userid,
        IsActive = false
        
      };
      _context.Entry(order).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return order;
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
