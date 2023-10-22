using Domain.Common;
using Domain.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Lesson> Lessons { get; set; }
    DbSet<Tag> Tags { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}