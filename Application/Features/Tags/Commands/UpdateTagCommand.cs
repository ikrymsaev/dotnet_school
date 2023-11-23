using Application.Features.Tags.Commands.Dto;
using Application.Features.Tags.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tags.Commands;

public record UpdateTagCommand(long Id, CreateTagDto Dto) : IRequest<TagVm?>;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, TagVm?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateTagCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TagVm?> Handle(UpdateTagCommand command, CancellationToken cancellationToken)
    {
        var tagEntity = await _dbContext.Tags
            .FirstOrDefaultAsync(t => t.Id == command.Id, cancellationToken);
        
        if (tagEntity is null) return null;

        tagEntity.Color = command.Dto.Color;
        tagEntity.Title = command.Dto.Title;
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TagVm>(tagEntity);
    }
}
