using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task AddMenuItemAsync(MenuItem menuItem);
    }
}
