using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;

namespace RestaurantReservation.Db.Services;

public class TableService : ITableService
{
    private readonly ITableRepository _repository;

    public TableService(ITableRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Table>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Table?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Table table)
    {
        await _repository.AddAsync(table);
    }

    public async Task UpdateAsync(Table table)
    {
        await _repository.UpdateAsync(table);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}