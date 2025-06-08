using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task<int> UpdateAsync(Employee employee);
    Task<int> DeleteAsync(int id);
}

