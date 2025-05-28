using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;

namespace RestaurantReservation.Db.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _repository;

    public MenuItemService(IMenuItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await _repository.AddAsync(menuItem);
    }

    public async Task UpdateAsync(MenuItem menuItem)
    {
        await _repository.UpdateAsync(menuItem);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}