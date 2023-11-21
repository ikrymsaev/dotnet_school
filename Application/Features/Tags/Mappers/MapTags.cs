using Application.Features.Tags.Commands.Dto;
using Application.Features.Tags.Queries.ViewModels;
using AutoMapper;
using Domain.Common;
using Domain.Tags.Entities;

namespace Application.Features.Tags.Mappers;

public class MapTags : Profile
{
    public MapTags()
    {
        CreateMap<Tag, TagVm>().ReverseMap();
        CreateMap<CreateTagDto, Tag>().ReverseMap();
    }
}