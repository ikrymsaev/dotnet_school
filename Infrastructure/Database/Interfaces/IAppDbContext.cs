using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Interfaces;

public interface IAppDbContext
{
    DbSet<Lesson> Lessons { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}