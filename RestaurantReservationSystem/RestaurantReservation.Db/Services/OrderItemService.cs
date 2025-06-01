using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;

namespace RestaurantReservation.Db.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _repository;

    public OrderItemService(IOrderItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<OrderItem?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        await _repository.AddAsync(orderItem);
    }

    public async Task<int> UpdateAsync(OrderItem orderItem)
    {
        return await _repository.UpdateAsync(orderItem);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}