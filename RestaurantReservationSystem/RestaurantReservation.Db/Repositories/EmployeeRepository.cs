using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Employee employee)
    {
        var existingEmployee = await GetByIdAsync(employee.Id);
        if (existingEmployee is null)
        {
            return -1;
        }

        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();

        return employee.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee is null)
        {
            return -1;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return employee.Id;
    }
}

