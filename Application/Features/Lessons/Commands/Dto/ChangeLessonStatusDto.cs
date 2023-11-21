using Domain.Lessons.ValueObjects;

namespace Application.Features.Lessons.Commands.Dto;

public class ChangeLessonStatusDto
{
    public ELessonStatus Status { get; set; }
}