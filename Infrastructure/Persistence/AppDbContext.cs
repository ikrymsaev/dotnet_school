using Application.Interfaces;
using Domain.Common;
using Domain.Courses;
using Domain.Lessons;
using Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Course> Courses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new LessonConfiguration());
        base.OnModelCreating(builder);
    }
}