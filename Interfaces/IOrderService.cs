
// Purpose: Defines operations for handling orders.

using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);  //create a new order
        Task DeleteOrderAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);   // retrieve an order by its ID

        Task<List<Order>> GetAllOrdersAsync();  // retrieve all orders
        Task<Order> UpdateOrderAsync(Order order);  // update an existing order
        Task DeleteMenuItemAsync(int id);

        Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId); // retrieve orders by customer ID

    }
}
