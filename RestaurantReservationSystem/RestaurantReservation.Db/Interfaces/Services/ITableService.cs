using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface ITableService
{
    Task<IEnumerable<Table>> GetAllAsync();
    Task<Table?> GetByIdAsync(int id);
    Task AddAsync(Table table);
    Task<int> UpdateAsync(Table table);
    Task<int> DeleteAsync(int id);
}