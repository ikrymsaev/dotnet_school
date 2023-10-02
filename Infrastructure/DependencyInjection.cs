using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = "Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=password";
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        
        return services;
    }
}