using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using RestaurantSystem.Infrastructure.Data;

//Purpose: Handles operations for menu items (for example: burgers, pizzas).

namespace RestaurantSystem.Services.Services
{
    public class MenuService : IMenuService
    {
        //The readonly ensures _context isn’t changed after initialization.
        private readonly RestaurantDbContext _context;


        //Uses Dependency Injection (DI) to receive the DbContext when the class is created
        public MenuService(RestaurantDbContext context)
        {
            _context = context;
        }

        //Methods to manage menu items which was defined in the IMenuService interface.
        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id) ?? throw new Exception("Menu item not found");
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = await GetMenuItemByIdAsync(id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MenuItem>> SearchMenuItemsAsync(string? category, string? name, bool? isAvailable)
        {
            var query = _context.MenuItems.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(m => m.Category == category);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(m => m.Name.Contains(name));

            if (isAvailable.HasValue)
                query = query.Where(m => m.IsAvailable == isAvailable.Value);

            return await query.ToListAsync();
        }

    }
}