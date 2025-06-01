using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Orders.FindAsync(id);
        if (item is null)
            return;

        _context.Orders.Remove(item);
        await _context.SaveChangesAsync();
    }
}

