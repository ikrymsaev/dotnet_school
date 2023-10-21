using Application.Features.Tags.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tags.Queries;

public record GetTagByIdQuery(long Id) : IRequest<TagDto?>;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTagByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TagDto?> Handle(GetTagByIdQuery query, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Tags
            .FirstOrDefaultAsync(t => t.Id == query.Id, cancellationToken);
        if (entity is null) return null;
        
        var dto = _mapper.Map<TagDto>(entity);
        return dto;
    }
}