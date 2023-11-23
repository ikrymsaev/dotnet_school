using Application.Features.Tags.Commands.Dto;
using Application.Features.Tags.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using Domain.Tags.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tags.Queries;

public record GetAllTagsQuery() : IRequest<List<TagVm>>;

public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagVm>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllTagsQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TagVm>> Handle(GetAllTagsQuery query, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Tags.ToListAsync(cancellationToken);
        var tagsList = _mapper.Map<List<Tag>, List<TagVm>>(result);
        
        return tagsList;
    }
}