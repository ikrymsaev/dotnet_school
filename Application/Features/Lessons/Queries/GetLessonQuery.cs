using MediatR;

namespace Application.Features.Lessons.Queries;

public class GetLessonQuery : IRequest<LessonVm>
{
    public Guid AuthorId { get; set; }
    public Guid Id { get; set; }

    public GetLessonQuery(Guid id) => Id = id;
}