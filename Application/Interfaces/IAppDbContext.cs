using Domain.Courses.Entities;
using Domain.Exams.Entities;
using Domain.Lessons.Entities;
using Domain.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Course> Courses { get; set; }
    DbSet<Lesson> Lessons { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<Exam> Exams { get; set; }
    DbSet<Question> Questions { get; set; }
    DbSet<Answer> Answers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}