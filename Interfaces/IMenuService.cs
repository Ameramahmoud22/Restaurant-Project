

using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync(); //return a list of all menu items
        Task<MenuItem> GetMenuItemByIdAsync(int id); //return a specific menu item by its ID
        Task AddMenuItemAsync(MenuItem menuItem); //add a new menu item

        Task UpdateMenuItemAsync(MenuItem menuItem); //update an existing menu item
        Task DeleteMenuItemAsync(int id); //delete a menu item by its ID
        Task<List<MenuItem>> SearchMenuItemsAsync(string? category, string? name, bool? isAvailable);

    }
}
