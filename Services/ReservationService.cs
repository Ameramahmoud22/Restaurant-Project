using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;
using RestaurantSystem.Infrastructure.Data;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantDbContext _context;

        public ReservationService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> ReserveTableAsync(Reservation reservation)
        {
            // Check table availability
            var isAvailable = !await _context.Reservations
                .AnyAsync(r => r.TableId == reservation.TableId && r.ReservationTime == reservation.ReservationTime);

            if (!isAvailable)
                throw new Exception("Table is not available at the requested time.");

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Table>> GetAvailableTablesAsync(DateTime reservationTime, int numberOfGuests)
        {
            var reservedTableIds = await _context.Reservations
                .Where(r => r.ReservationTime == reservationTime)
                .Select(r => r.TableId)
                .ToListAsync();

            return await _context.Tables
                .Where(t => t.Capacity >= numberOfGuests && !reservedTableIds.Contains(t.Id))
                .ToListAsync();
        }

        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null) return false;
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
