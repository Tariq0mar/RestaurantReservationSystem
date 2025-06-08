using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Repositories;

public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task AddAsync(Restaurant restaurant);
    Task<int> UpdateAsync(Restaurant restaurant);
    Task<int> DeleteAsync(int id);
}
