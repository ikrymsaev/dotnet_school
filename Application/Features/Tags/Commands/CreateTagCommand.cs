using Application.Features.Tags.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using FluentValidation;
using MediatR;

namespace Application.Features.Tags.Commands;

/// <summary>
/// Команда для создания тэга
/// </summary>
/// <param name="CreateDto">ДТО нового тэга</param>
public record CreateTagCommand(CreateTagDto CreateDto) : IRequest<TagDto>;

/// <summary>
/// Обработчик создания тэга
/// </summary>
public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagDto>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateTagCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TagDto> Handle(CreateTagCommand command, CancellationToken cancellationToken)
    {
        var tagEntity = _mapper.Map<Tag>(command.CreateDto);
        
        var result = await _dbContext.Tags.AddAsync(tagEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TagDto>(result.Entity);
    }
}