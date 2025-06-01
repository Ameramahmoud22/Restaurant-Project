
// Purpose: Defines operations for handling orders.

using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);  //create a new order
        Task<Order> GetOrderByIdAsync(int id);   // retrieve an order by its ID
    }
}
