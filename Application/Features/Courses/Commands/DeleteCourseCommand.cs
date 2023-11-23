using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Commands;

public record DeleteCourseCommand(long CourseId) : IRequest<long?>;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, long?>
{
    private readonly IAppDbContext _dbContext;

    public DeleteCourseCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long?> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        if (entity is null) return null;
        
        _dbContext.Courses.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return request.CourseId;
    }
}