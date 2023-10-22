using Application.Common;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(typeof(Startup).Assembly)
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        
        return services;
    }
}