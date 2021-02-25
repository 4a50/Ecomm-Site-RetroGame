using System.Threading.Tasks;

namespace EcommerceApp.Models.Interfaces
{
  public interface IOrder
  {
    public Task<Order> CreateNewOrder(string userid);
    public Task<Order> AddOrder(Order order);
    public Task<Order> RemoveOrder(int Id);
    public Task<Order> UpdateOrder(Order order);
    public Task<Order> GetOrder(int id);
  }
}