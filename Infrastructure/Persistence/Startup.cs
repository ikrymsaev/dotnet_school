using Application.Interfaces;
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
            .AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string connectionString)
    {
        return builder.UseNpgsql(connectionString);
    }
}