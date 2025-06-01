using System.Text.Json.Serialization;

namespace RestaurantSystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        
        [JsonIgnore]
        public  Order ? Order { get; set; } 
        public int MenuItemId { get; set; }
        public required MenuItem MenuItem { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
