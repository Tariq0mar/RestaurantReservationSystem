using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservationSystem.configurations;

public static class RepositoryDependencyInjections
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}