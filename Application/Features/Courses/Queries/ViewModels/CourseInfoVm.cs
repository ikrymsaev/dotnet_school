using Application.Features.Lessons.Commands.Dto;
using Application.Features.Lessons.Queries.ViewModels;
using Domain.Courses.ValueObjects;

namespace Application.Features.Courses.Queries.ViewModels;

public class CourseInfoVm
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = "";
    public List<LessonVm> Lessons { get; set; } = null!;
    public ECourseStatus Status { get; set; }
}