using Infrastructure.Persistence;
using Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddPersistence(config);
    }

    public static void InitializeDatabase(this IServiceProvider services,
        CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        DatabaseInitializer.InitializeDatabase(context);
    }
}