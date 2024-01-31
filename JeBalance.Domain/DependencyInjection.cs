using JeBalance.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JeBalance.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddSingleton<IHorodatageProvider, HorodatageProvider>();
        services.AddSingleton<IdOpaqueProvider, OpaqueProvider>();
        return services;
    }
}