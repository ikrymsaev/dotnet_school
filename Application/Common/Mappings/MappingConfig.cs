using Application.Features.Lessons.Dto;
using Application.Features.Lessons.Queries;
using Application.Features.Tags.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Lessons;

namespace Application.Common.Mappings;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Lesson, LessonDto>().ReverseMap();
    }
}