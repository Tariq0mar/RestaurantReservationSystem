using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Contexts;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }


    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
        : base(options)
    {
    }
}
