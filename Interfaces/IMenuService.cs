
//Purpose: Defines operations for managing menu items in your restaurant system.

using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync(); //return a list of all menu items
        Task<MenuItem> GetMenuItemByIdAsync(int id); //return a specific menu item by its ID
        Task AddMenuItemAsync(MenuItem menuItem); //add a new menu item
    }
}
