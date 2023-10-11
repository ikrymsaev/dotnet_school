namespace Infrastructure.Persistence.Initialization;

public static class DatabaseInitializer
{
    public static void InitializeDatabase(AppDbContext context)
    {
        context.Database.EnsureCreated();
    }
}