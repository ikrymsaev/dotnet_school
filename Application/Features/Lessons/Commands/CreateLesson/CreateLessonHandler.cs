using Domain.Entities;
using Infrastructure.Database.Interfaces;
using MediatR;

namespace Application.Features.Lessons.Commands.CreateLesson;

public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, Guid>
{
    private readonly IAppDbContext _dbContext;

    public CreateLessonHandler(IAppDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = new Lesson
        {
            Id = Guid.NewGuid(),
            AuthorId = request.AuthorId,
            Title = request.Title,
            Description = request.Description
        };
        await _dbContext.Lessons.AddAsync(lesson, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return lesson.Id;
    }
}