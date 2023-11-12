using Domain.Common.Enums;

namespace Application.Features.Courses.ViewModel;

public class CourseVm
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ECourseStatus Status { get; set; }
}