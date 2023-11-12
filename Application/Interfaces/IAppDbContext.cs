using Domain.Common;
using Domain.Courses;
using Domain.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Lesson> Lessons { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<Course> Courses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}