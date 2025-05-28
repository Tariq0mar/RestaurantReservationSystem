using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface ITableService
{
    Task<IEnumerable<Table>> GetAllAsync();
    Task<Table?> GetByIdAsync(int id);
    Task AddAsync(Table table);
    Task UpdateAsync(Table table);
    Task DeleteAsync(int id);
}