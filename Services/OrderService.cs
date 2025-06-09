using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using RestaurantSystem.Infrastructure.Data;
namespace RestaurantSystem.Services
{

    // Purpose: Implements operations for handling orders, such as creating and retrieving orders.
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _context;


        //Constructor: uses DI to get the RestaurantDbContext
        public OrderService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            order.OrderDate = DateTime.UtcNow;
            order.TotalAmount = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id) ?? throw new Exception("Order not found");
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                throw new Exception("Order not found");
            }
            existingOrder.CustomerId = order.CustomerId;
            existingOrder.OrderItems = order.OrderItems;
            existingOrder.TotalAmount = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);
            existingOrder.OrderDate = DateTime.UtcNow;
            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public Task DeleteMenuItemAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }
    }
}
