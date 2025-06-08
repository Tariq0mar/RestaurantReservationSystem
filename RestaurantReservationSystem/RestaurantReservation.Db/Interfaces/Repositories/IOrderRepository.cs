using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task<int> UpdateAsync(Order order);
    Task<int> DeleteAsync(int id);
}
