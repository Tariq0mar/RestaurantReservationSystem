using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Repositories;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> GetAllAsync();
    Task<OrderItem?> GetByIdAsync(int id);
    Task AddAsync(OrderItem orderItem);
    Task<int> UpdateAsync(OrderItem orderItem);
    Task<int> DeleteAsync(int id);
}
