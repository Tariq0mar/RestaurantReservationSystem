using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(int id);
    Task AddAsync(Reservation reservation);
    Task<int> UpdateAsync(Reservation reservation);
    Task<int> DeleteAsync(int id);
}