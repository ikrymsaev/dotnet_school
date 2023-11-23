using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Commands;

public record AddTagsToLessonCommand(long LessonId, List<long> TagIds) : IRequest<List<long>?>;

public class AddTagsToLessonCommandHandler : IRequestHandler<AddTagsToLessonCommand, List<long>?>
{
    private readonly IAppDbContext _dbContext;

    public AddTagsToLessonCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<long>?> Handle(AddTagsToLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _dbContext.Lessons
            .Include(c => c.Tags)
            .FirstOrDefaultAsync(c => c.Id == request.LessonId, cancellationToken);
        if (lesson is null) return null;
        
        var alreadyIncludedIds = lesson.Tags
            .FindAll(c => request.TagIds.Contains(c.Id))
            .Select(el => el.Id)
            .ToList();
        if (alreadyIncludedIds.Count > 0)
            throw new Exception($"Тэги с Id: {string.Join(", ", alreadyIncludedIds)} уже прикреплены к уроку");

        var tags = _dbContext.Tags
            .Where(l => request.TagIds.Contains(l.Id))
            .ToList();
        tags.ForEach(tag => lesson.Tags.Add(tag));

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return request.TagIds;
    }
}