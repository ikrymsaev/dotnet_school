using Application.Features.Courses.ViewModel;
using AutoMapper;
using Domain.Courses;
using Domain.Courses.Dto;

namespace Application.Features.Courses;

public class MappingCourses : Profile
{
    public MappingCourses()
    {
        CreateMap<Course, CourseVm>().ReverseMap();
        CreateMap<CreateCourseDto, Course>().ReverseMap();
    }
}