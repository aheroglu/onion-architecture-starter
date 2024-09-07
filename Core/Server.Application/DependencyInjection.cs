using Microsoft.Extensions.DependencyInjection;

namespace Server.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(conf =>
                conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services
            .AddAutoMapper(typeof(DependencyInjection).Assembly);

        return services;
    }
}
