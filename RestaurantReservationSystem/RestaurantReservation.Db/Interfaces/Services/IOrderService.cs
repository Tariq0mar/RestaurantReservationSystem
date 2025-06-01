using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task<int> UpdateAsync(Order order);
    Task<int> DeleteAsync(int id);
}