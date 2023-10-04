using Infrastructure.Persistence.Initialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

internal static class Startup
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services
            .AddDbContext<AppDbContext>((p, m) =>
            {
                m.UseDatabase("Host=localhost;Port=5432;Database=school_db;Username=postgres;Password=postgres");
            })
            .AddTransient<IDatabaseInitializer, DatabaseInitializer>();
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string connectionString)
    {
        return builder.UseNpgsql(connectionString, e =>
            e.MigrationsAssembly("Migrations.PostgreSQL"));
    }
}