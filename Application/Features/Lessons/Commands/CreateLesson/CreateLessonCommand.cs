using MediatR;

namespace Application.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommand : IRequest<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
}

