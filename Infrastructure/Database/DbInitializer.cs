﻿namespace Infrastructure.Database;

public class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();
    }
}