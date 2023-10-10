using Domain.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Lesson> Lessons { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}