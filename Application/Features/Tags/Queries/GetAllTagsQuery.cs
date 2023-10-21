using Application.Features.Tags.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tags.Queries;

public record GetAllTagsQuery() : IRequest<List<TagDto>>;

public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagDto>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllTagsQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TagDto>> Handle(GetAllTagsQuery query, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Tags.ToListAsync(cancellationToken);
        
        var tagsList = _mapper.Map<List<Tag>, List<TagDto>>(result);
        
        Console.WriteLine(tagsList);
        return tagsList;
    }
}