using Application.Features.Lessons.Queries;
using AutoMapper;
using Domain.Lessons;

namespace Application.Common.Mappings;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Lesson, LessonDto>().ReverseMap();
    }
}