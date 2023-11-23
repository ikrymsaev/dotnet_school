using Application.Features.Lessons.Commands.Dto;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Commands;

public record ChangeLessonStatusCommand(long LessonId, ChangeLessonStatusDto dto) : IRequest<ChangeLessonStatusDto?>;

public class ChangeLessonStatusCommandHandler : IRequestHandler<ChangeLessonStatusCommand, ChangeLessonStatusDto?>
{
    private readonly IAppDbContext _dbContext;

    public ChangeLessonStatusCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ChangeLessonStatusDto?> Handle(ChangeLessonStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons
            .FirstOrDefaultAsync(c => c.Id == request.LessonId, cancellationToken);
        if (entity is null) return null;

        entity.ChangeStatus(request.dto.Status);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return request.dto;
    }
}