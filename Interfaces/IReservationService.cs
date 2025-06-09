using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> ReserveTableAsync(Reservation reservation);
        Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<List<Table>> GetAvailableTablesAsync(DateTime reservationTime, int numberOfGuests);
        Task<bool> CancelReservationAsync(int reservationId);
    }
}
