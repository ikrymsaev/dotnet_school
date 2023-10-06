using Application.Shared.Mappings;
using AutoMapper;
using Domain.Lessons;

namespace Application.Features.Lessons.Queries;

public class LessonVm : IMapWith<Lesson>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Lesson, LessonVm>()
            .ForMember(vm => vm.Title,
                opt => opt.MapFrom(lesson => lesson.Title))
            .ForMember(vm => vm.Description,
                opt => opt.MapFrom(lesson => lesson.Description))
            .ForMember(vm => vm.Id,
                opt => opt.MapFrom(lesson => lesson.Id));
    }
}