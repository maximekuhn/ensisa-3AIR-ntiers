namespace JeBalance.API.Interne.Securisee;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        return services;
    }
}