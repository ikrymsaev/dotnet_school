using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Commands;

public record DeleteLessonCommand(long LessonId) : IRequest<long?>;

public class DeleteLessonDtoHandler : IRequestHandler<DeleteLessonCommand, long?>
{
    private readonly IAppDbContext _dbContext;

    public DeleteLessonDtoHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long?> Handle(DeleteLessonCommand command, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons.FirstOrDefaultAsync(l => l.Id == command.LessonId);
        if (entity is null) return null;
        _dbContext.Lessons.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return command.LessonId;
    }
}