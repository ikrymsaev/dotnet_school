using Application.Features.Tags.Commands.Dto;
using Application.Features.Tags.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tags.Queries;

public record GetTagByIdQuery(long Id) : IRequest<TagVm?>;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagVm?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTagByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TagVm?> Handle(GetTagByIdQuery query, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Tags
            .FirstOrDefaultAsync(t => t.Id == query.Id, cancellationToken);
        if (entity is null) return null;
        
        var dto = _mapper.Map<TagVm>(entity);
        return dto;
    }
}