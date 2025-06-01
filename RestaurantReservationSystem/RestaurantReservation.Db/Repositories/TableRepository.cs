using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Table>> GetAllAsync()
    {
        return await _context.Tables.ToListAsync();
    }

    public async Task<Table?> GetByIdAsync(int id)
    {
        return await _context.Tables.FindAsync(id);
    }

    public async Task AddAsync(Table table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Table table)
    {
        var existingTable = await GetByIdAsync(table.Id);
        if (existingTable is null)
        {
            return -1;
        }

        _context.Tables.Update(table);
        await _context.SaveChangesAsync();

        return table.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await _context.Tables.FindAsync(id);
        if (item is null)
        {
            return -1;
        }

        _context.Tables.Remove(item);
        await _context.SaveChangesAsync();

        return id;
    }
}
