using Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(IServiceCollection).Assembly;
        services
            .AddMediatR(config => config.RegisterServicesFromAssembly(assembly))
            .AddAutoMapper(typeof(MappingConfig));
        
        return services;
    }
}