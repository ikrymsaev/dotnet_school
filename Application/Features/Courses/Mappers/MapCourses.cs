using Application.Features.Courses.Commands.Dto;
using Application.Features.Courses.Queries.ViewModels;
using AutoMapper;
using Domain.Courses.Entities;

namespace Application.Features.Courses.Mappers;

public class MapCourses : Profile
{
    public MapCourses()
    {
        CreateMap<Course, CourseInfoVm>();
        CreateMap<Course, CourseVm>()
            .ForMember(
                c => c.LessonsCount,
                opt => opt.MapFrom(x => x.Lessons.Count));
        
        CreateMap<CreateCourseDto, Course>().ReverseMap();
    }
}