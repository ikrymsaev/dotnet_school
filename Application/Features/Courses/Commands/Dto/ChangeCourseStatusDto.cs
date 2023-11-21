using Domain.Courses.ValueObjects;

namespace Application.Features.Courses.Commands.Dto;

public class ChangeCourseStatusDto
{
    public ECourseStatus Status { get; set; }
}