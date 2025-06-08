using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.Services;

namespace RestaurantReservationSystem.configurations;

public static class ServiceDependencyInjections
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}