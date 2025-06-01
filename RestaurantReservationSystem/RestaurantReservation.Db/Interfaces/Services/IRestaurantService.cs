using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task AddAsync(Restaurant restaurant);
    Task UpdateAsync(Restaurant restaurant);
    Task DeleteAsync(int id);
}