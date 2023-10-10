namespace Infrastructure.Persistence.Initialization;

public class DatabaseInitializer : IDatabaseInitializer
{
    public async Task InitializeDatabaseAsync(AppDbContext context, CancellationToken cancellationToken)
    {
        context.Database.EnsureCreated();
    }
}