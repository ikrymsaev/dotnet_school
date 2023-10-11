using Application.Common.Mappings;
using Application.Features.Lessons.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(typeof(Startup).Assembly)
            .AddAutoMapper(typeof(MappingConfig));
        
        return services;
    }
}