using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : IOrderItemRepository
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

    public async Task<int> UpdateAsync(OrderItem orderItem)
    {
        var existingOrderItem = await GetByIdAsync(orderItem.Id);
        if (existingOrderItem is null)
        {
            return -1;
        }

        _context.OrderItems.Update(orderItem);
        await _context.SaveChangesAsync();

        return orderItem.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await _context.OrderItems.FindAsync(id);
        if (item is null)
        {
            return -1; 
        }

        _context.OrderItems.Remove(item);
        await _context.SaveChangesAsync();

        return id;
    }
}

