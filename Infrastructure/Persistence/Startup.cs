using Application.Interfaces;
using Infrastructure.Persistence.Initialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

internal static class Startup
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var psqlConnect = config["PsqlConnection"];
        return services
            .AddDbContext<AppDbContext>((p, m) =>
            {
                if (psqlConnect is null) return;
                m.UseDatabase(psqlConnect);
            })
            .AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string connectionString)
    {
        return builder.UseNpgsql(connectionString);
    }
}