using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task<int> UpdateAsync(Employee employee);
    Task<int> DeleteAsync(int id);
}
