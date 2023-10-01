using Application.Shared.Mappings;
using AutoMapper;

namespace Application.Features.Lessons.Queries;

public class LessonVm : IMapWith<Domain.Entities.Lesson>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Lesson, LessonVm>()
            .ForMember(vm => vm.Title,
                opt => opt.MapFrom(lesson => lesson.Title))
            .ForMember(vm => vm.Description,
                opt => opt.MapFrom(lesson => lesson.Description))
            .ForMember(vm => vm.Id,
                opt => opt.MapFrom(lesson => lesson.Id));
    }
}