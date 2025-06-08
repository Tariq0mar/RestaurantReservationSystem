using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;

namespace RestaurantReservation.Db.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Employee employee)
    {
        await _repository.AddAsync(employee);
    }

    public async Task<int> UpdateAsync(Employee employee)
    {
        return await _repository.UpdateAsync(employee);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

}