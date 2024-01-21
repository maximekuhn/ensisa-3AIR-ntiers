using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JeBalance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<DenonciationRepository, DenonciationRepositorySQLite>();
        services.AddScoped<SuspectRepository, SuspectRepositorySQLite>();
        services.AddScoped<InformateurRepository, InformateurRepositorySQLite>();
        services.AddScoped<ReponseRepository, ReponseRepositorySQLite>();
        return services;
    }
}