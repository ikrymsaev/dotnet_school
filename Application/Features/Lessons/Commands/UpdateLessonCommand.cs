using Application.Features.Lessons.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Commands;

public record UpdateLessonCommand(long LessonId, CreateLessonDto LessonDto) : IRequest<LessonDto?>;

public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, LessonDto?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateLessonCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LessonDto?> Handle(UpdateLessonCommand command, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons
            .FirstOrDefaultAsync(l => l.Id == command.LessonId, cancellationToken);
        if (entity is null) return null;

        entity.Title = command.LessonDto.Title;
        entity.Description = command.LessonDto.Description;
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LessonDto>(entity);
    }
}