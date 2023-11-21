using Application.Features.Tags.Queries.ViewModels;
using Domain.Lessons.ValueObjects;

namespace Application.Features.Lessons.Queries.ViewModels;

public class LessonInfoVm
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = "";
    public List<TagVm> Tags { get; set; } = null!;
    public ELessonStatus Status { get; set; }
}