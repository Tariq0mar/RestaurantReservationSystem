using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface IMenuItemService
{
    Task<IEnumerable<MenuItem>> GetAllAsync();
    Task<MenuItem?> GetByIdAsync(int id);
    Task AddAsync(MenuItem menuItem);
    Task<int> UpdateAsync(MenuItem menuItem);
    Task<int> DeleteAsync(int id);
}