using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Services;

namespace RestaurantReservationSystem.configurations;

public static class ServiceDependencyInjections
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<ITableService, TableService>();

        return services;
    }
}