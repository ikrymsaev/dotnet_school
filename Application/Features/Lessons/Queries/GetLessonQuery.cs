using Domain.Lessons;
using MediatR;

namespace Application.Features.Lessons.Queries;

public class GetLessonQuery : IRequest<Lesson>
{
    public long Id { get; set; }

    public GetLessonQuery(long id) => Id = id;
}