using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Repositories;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Persistence.Context;
using Server.Persistence.Repositories;
using Server.Persistence.Services;

namespace Server.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration
            .GetConnectionString("SqlServer")!;

        services
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        services
            .AddIdentityCore<AppUser>()
            .AddEntityFrameworkStores<AppDbContext>();

        services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services
            .AddScoped<IUnitOfWork, UnitOfWork>();

        services
            .AddScoped<IJwtService, JwtService>();

        return services;
    }
}
