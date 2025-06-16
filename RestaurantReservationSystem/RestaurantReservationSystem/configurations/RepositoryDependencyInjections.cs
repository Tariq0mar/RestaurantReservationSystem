using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservationSystem.configurations;

public static class RepositoryDependencyInjections
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<ITableRepository, TableRepository>();

        return services;
    }
}