using Application.Features.Tags.Dto;
using AutoMapper;
using Domain.Common;

namespace Application.Features.Tags.Mapping;

public class MappingTags : Profile
{
    public MappingTags()
    {
        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<CreateTagDto, Tag>().ReverseMap();
    }
}