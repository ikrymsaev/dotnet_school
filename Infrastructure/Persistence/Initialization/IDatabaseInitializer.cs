using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Initialization;

internal interface IDatabaseInitializer
{
    Task InitializeDatabaseAsync(AppDbContext dbContext, CancellationToken cancellationToken);
}