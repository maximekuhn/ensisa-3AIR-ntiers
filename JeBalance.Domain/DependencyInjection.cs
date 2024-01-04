using JeBalance.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JeBalance.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        // TODO: move to infra
        services.AddScoped<DenonciationRepository, DummyDenonciationRepository>();
        return services;
    }
}