using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Order ID mismatch.");
            }
            var updatedOrder = await _orderService.CreateOrderAsync(order);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}