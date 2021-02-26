﻿using EcommerceApp.Data;
using EcommerceApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
        IsActive = false,
        PaymentComplete = false
      };
      _context.Entry(order).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return order;
    }
    public async Task<Order> GetCurrentOrder(string userId)
    {
      var order = await _context.Order     
        .Where(o => o.UserId == userId && o.PaymentComplete == false)
        .Include(c => c.Cart)
        .ThenInclude(c =>c.CartGames)
        .ThenInclude(g => g.Game)
        .FirstOrDefaultAsync();
      return order;
    }
    public async Task<Order> GetOrderAll(string userId)
    {
      var order = await _context.Order
        .Where(o => o.UserId == userId)
        .Include(c => c.Cart)
        .ThenInclude(c => c.CartGames)
        .ThenInclude(g => g.Game)
        .FirstOrDefaultAsync();
      return order;
    }

    public Task<Order> RemoveOrder(int Id)
    {
      throw new NotImplementedException();
    }

    public async Task UpdateOrder(Order order)
    {
      _context.Entry(order).State = EntityState.Modified;
      await _context.SaveChangesAsync();

    }
  }
}
