using Azure;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        // Constructor injection for the IMenuService
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItems = await _menuService.GetAllMenuItemsAsync(); // Fetch all menu items asynchronously
            return Ok(menuItems); // Return 200 OK with the list of menu items
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menuItem = await _menuService.GetMenuItemByIdAsync(id); // Fetch the menu item by ID
            return Ok(menuItem);  
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItem menuItem)
        {
            await _menuService.AddMenuItemAsync(menuItem);
            return CreatedAtAction(nameof(GetById), new { id = menuItem.Id }, menuItem); // Return 201 Created with the location of the new resource (EX: /api/Menu/1) and the item’s data.
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return BadRequest("Menu item ID mismatch."); // Return 400 Bad Request if the ID in the URL does not match the ID in the body
            }
            await _menuService.UpdateMenuItemAsync(menuItem); // Update the menu item
            return NoContent(); // Return 204 No Content to indicate success without returning any content
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuService.DeleteMenuItemAsync(id); // Delete the menu item by ID
            return NoContent(); // Return 204 No Content to indicate success without returning any content
        }
    }
}