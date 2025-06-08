using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task AddAsync(Restaurant restaurant);
    Task<int> UpdateAsync(Restaurant restaurant);
    Task<int> DeleteAsync(int id);
}