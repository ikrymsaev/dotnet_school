using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Commands;

public record IncludeLessonsToCourse(long courseId, List<long> lessonIds) : IRequest<List<long>?>;

public class IncludeLessonsToCourseHandler : IRequestHandler<IncludeLessonsToCourse, List<long>?>
{
    private readonly IAppDbContext _dbContext;

    public IncludeLessonsToCourseHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<long>?> Handle(IncludeLessonsToCourse request, CancellationToken cancellationToken)
    {
        var course = await _dbContext.Courses
            .Include(c => c.Lessons)
            .FirstOrDefaultAsync(c => c.Id == request.courseId, cancellationToken);
        if (course is null) return null;

        // Проверяем на наличие уже включенных уроков в курс
        var alreadyIncludedIds = course.Lessons
            .FindAll(c => request.lessonIds.Contains(c.Id))
            .Select(el => el.Id)
            .ToList();
        // Если есть ИД с уже добавленным уроком, бросаем исключение
        if (alreadyIncludedIds.Count > 0)
            throw new Exception($"Lessons with Ids: {string.Join(", ", alreadyIncludedIds)} is already exist in course");

        // Получаем модели уроков
        var lessons = _dbContext.Lessons
            .Where(l => request.lessonIds.Contains(l.Id))
            .ToList();
        // Заполняем связи в many-to-many
        lessons.ForEach(lesson => course.Lessons.Add(lesson));

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return request.lessonIds;
    }
}