using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using RestaurantSystem.Infrastructure.Data;

namespace RestaurantSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RestaurantDbContext _context;

        public CustomerService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateCustomerAsync(Customer customer)
        {
            var existing = await _context.Customers.FindAsync(customer.Id);
            if (existing == null) return null;

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
