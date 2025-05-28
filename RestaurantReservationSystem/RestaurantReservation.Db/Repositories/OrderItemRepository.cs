using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        return await _context.OrderItems.ToListAsync();
    }

    public async Task<OrderItem?> GetByIdAsync(int id)
    {
        return await _context.OrderItems.FindAsync(id);
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.OrderItems.FindAsync(id);
        if (item is null)
            return;

        _context.OrderItems.Remove(item);
        await _context.SaveChangesAsync();
    }
}

