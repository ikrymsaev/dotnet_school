using MediatR;

namespace Application.Features.Lessons.Queries;

public class GetLessonQuery : IRequest<LessonVm>
{
    public int Id { get; set; }

    public GetLessonQuery(int id) => Id = id;
}