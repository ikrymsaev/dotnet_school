using Application.Features.Lessons.Commands.Dto;
using Application.Features.Lessons.Queries.ViewModels;
using AutoMapper;
using Domain.Lessons;
using Domain.Lessons.Entities;

namespace Application.Features.Lessons.Mappers;

public class MapLessons : Profile
{
    public MapLessons()
    {
        CreateMap<Lesson, LessonVm>();
        CreateMap<Lesson, LessonInfoVm>();
        
        CreateMap<CreateLessonDto, Lesson>().ReverseMap();
    }
}