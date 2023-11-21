using Domain.Lessons.ValueObjects;

namespace Application.Features.Lessons.Queries.ViewModels;

public class LessonVm
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = "";
    public ELessonStatus Status { get; set; }
}