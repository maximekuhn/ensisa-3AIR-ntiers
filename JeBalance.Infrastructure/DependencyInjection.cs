using JeBalance.Architecture.SQLite.Repositories;
using JeBalance.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JeBalance.Architecture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<DenonciationRepository, DenonciationRepositorySQLite>();
        return services;
    }
}