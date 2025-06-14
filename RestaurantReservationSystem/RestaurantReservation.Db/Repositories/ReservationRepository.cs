using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task AddAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Reservation reservation)
    {
        var existingReservation = await GetByIdAsync(reservation.Id);
        if (existingReservation is null)
        {
            return -1;
        }

        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();

        return reservation.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await _context.Reservations.FindAsync(id);
        if (item != null)
        {
            return -1;
        }

        _context.Reservations.Remove(item);
        await _context.SaveChangesAsync();

        return id;
    }
}

