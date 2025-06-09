namespace RestaurantSystem.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public required string Description { get; set; } 
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true; // Default to true, indicating the item is available
    }
}
