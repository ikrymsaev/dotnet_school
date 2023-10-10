namespace Infrastructure.Persistence.Initialization;

public class DatabaseInitializer
{
    public static void InitializeDatabase(AppDbContext context)
    {
        context.Database.EnsureCreated();
    }
}