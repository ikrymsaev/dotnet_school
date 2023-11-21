using Application.Features.Courses.Commands.Dto;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Commands;

public record ChangeCourseStatusCommand(long CourseId, ChangeCourseStatusDto dto) : IRequest<ChangeCourseStatusDto?>;

public class ChangeCourseStatusCommandHandler : IRequestHandler<ChangeCourseStatusCommand, ChangeCourseStatusDto?>
{
    private readonly IAppDbContext _dbContext;

    public ChangeCourseStatusCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ChangeCourseStatusDto?> Handle(ChangeCourseStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        if (entity is null) return null;

        entity.ChangeStatus(request.dto.Status);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return request.dto;
    }
}