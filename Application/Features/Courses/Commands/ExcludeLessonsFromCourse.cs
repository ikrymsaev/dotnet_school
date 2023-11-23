using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Commands;

public record ExcludeLessonsFromCourse(long courseId, List<long> lessonIds) : IRequest<List<long>?>;

public class ExcludeLessonsFromCourseHandler : IRequestHandler<ExcludeLessonsFromCourse, List<long>?>
{
    private readonly IAppDbContext _dbContext;

    public ExcludeLessonsFromCourseHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<long>?> Handle(ExcludeLessonsFromCourse request, CancellationToken cancellationToken)
    {
        var course = await _dbContext.Courses
            .Include(c => c.Lessons)
            .FirstOrDefaultAsync(c => c.Id == request.courseId, cancellationToken);
        if (course is null) return null;

        var hasNotIncludedIds = request.lessonIds
            .FindAll(id => course.Lessons.Find(l => l.Id == id) is null);
        
        // Если есть урок, которого нет в курсе, бросаем исключение
        if (hasNotIncludedIds.Count > 0)
            throw new Exception($"Уроки с ID: {string.Join(", ", hasNotIncludedIds)} не включены в курс");
        // Получаем модели уроков
        var lessons = _dbContext.Lessons
            .Where(l => request.lessonIds.Contains(l.Id))
            .ToList();
        // Удаляем связи в many-to-many
        lessons.ForEach(lesson => course.Lessons.Remove(lesson));
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return request.lessonIds;
    }
}