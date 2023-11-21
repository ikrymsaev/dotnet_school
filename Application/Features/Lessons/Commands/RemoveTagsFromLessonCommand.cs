using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Commands;

public record RemoveTagsFromLessonCommand(long LessonId, List<long> TagIds) : IRequest<List<long>?>;

public class RemoveTagsFromLessonCommandHandler : IRequestHandler<RemoveTagsFromLessonCommand, List<long>?>
{
    private readonly IAppDbContext _dbContext;

    public RemoveTagsFromLessonCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<long>?> Handle(RemoveTagsFromLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _dbContext.Lessons
            .Include(c => c.Tags)
            .FirstOrDefaultAsync(c => c.Id == request.LessonId, cancellationToken);
        if (lesson is null) return null;
        
        var hasNotIncludedIds = request.TagIds
            .FindAll(id => lesson.Tags.Find(l => l.Id == id) is null);
        
        if (hasNotIncludedIds.Count > 0)
            throw new Exception($"Тэги с Id: {string.Join(", ", hasNotIncludedIds)} не прикреплены к уроку");

        var tags = _dbContext.Tags
            .Where(l => request.TagIds.Contains(l.Id))
            .ToList();
        
        tags.ForEach(tag => lesson.Tags.Remove(tag));

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return request.TagIds;
    }
}