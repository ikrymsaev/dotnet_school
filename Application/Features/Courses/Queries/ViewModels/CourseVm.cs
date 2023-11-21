using Domain.Courses.ValueObjects;

namespace Application.Features.Courses.Queries.ViewModels;

public class CourseVm
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = "";
    public ECourseStatus Status { get; set; }
    public int LessonsCount { get; set; }
}