using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;

namespace RestaurantReservation.Db.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Customer customer)
    {
        await _repository.AddAsync(customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}

