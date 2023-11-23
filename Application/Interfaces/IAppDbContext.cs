using Domain.Common;
using Domain.Courses.Entities;
using Domain.Lessons;
using Domain.Lessons.Entities;
using Domain.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Lesson> Lessons { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<Course> Courses { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}