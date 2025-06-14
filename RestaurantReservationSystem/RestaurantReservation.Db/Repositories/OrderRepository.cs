using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
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

    public async Task<int> UpdateAsync(Order order)
    {
        var existingOrder = await GetByIdAsync(order.Id);
        if (existingOrder is null)
        {
            return -1;
        }

        _context.Orders.Update(order);
        await _context.SaveChangesAsync();

        return order.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await _context.Orders.FindAsync(id);
        if (item is null)
        {
            return -1;
        }
        
        _context.Orders.Remove(item);
        await _context.SaveChangesAsync();

        return id;
    }
}

