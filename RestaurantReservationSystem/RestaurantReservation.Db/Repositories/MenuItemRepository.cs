using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        return await _context.MenuItems.FindAsync(id);
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(MenuItem menuItem)
    {
        var existingMenuIteme = await GetByIdAsync(menuItem.Id);
        if (existingMenuIteme is null)
        {
            return -1;
        }

        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();

        return menuItem.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await _context.MenuItems.FindAsync(id);
        if (item is null)
        {
            return -1;
        }

        _context.MenuItems.Remove(item);
        await _context.SaveChangesAsync();

        return id;
    }
}

