using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RestaurantReservationDbContext _context;

    public UserRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(User user)
    {
        var existingUser = await GetByIdAsync(user.Id);
        if (existingUser is null)
        {
            return -1;
        }

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
        {
            return -1;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }
}

