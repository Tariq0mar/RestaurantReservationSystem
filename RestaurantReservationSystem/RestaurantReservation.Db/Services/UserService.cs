using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;

namespace RestaurantReservation.Db.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(User user)
    {
        await _repository.AddAsync(user);
    }

    public async Task<int> UpdateAsync(User user)
    {
        return await _repository.UpdateAsync(user);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}

