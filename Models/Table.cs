namespace RestaurantSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<Reservation> Reservations { get; set; } = new();
    }
}
