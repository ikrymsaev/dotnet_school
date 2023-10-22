using Application.Features.Lessons.Dto;
using AutoMapper;
using Domain.Lessons;

namespace Application.Features.Lessons.Mappings;

public class MappingLessons : Profile
{
    public MappingLessons()
    {
        CreateMap<Lesson, LessonDto>().ReverseMap();
        CreateMap<CreateLessonDto, Lesson>().ReverseMap();
    }
}