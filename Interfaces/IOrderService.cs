using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
