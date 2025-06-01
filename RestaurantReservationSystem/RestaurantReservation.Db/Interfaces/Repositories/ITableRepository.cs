using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Repositories;

public interface ITableRepository
{
    Task<IEnumerable<Table>> GetAllAsync();
    Task<Table?> GetByIdAsync(int id);
    Task AddAsync(Table table);
    Task UpdateAsync(Table table);
    Task DeleteAsync(int id);
}
