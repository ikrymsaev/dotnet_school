using Application.Features.Lessons.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons;
using MediatR;

namespace Application.Features.Lessons.Commands;

public record CreateLessonCommand(CreateLessonDto Dto) : IRequest<LessonDto>;

// Обработчик создания нового занятия.
public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, LessonDto>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateLessonCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LessonDto> Handle(CreateLessonCommand command, CancellationToken cancellationToken)
    {
        var newLessonModel = new Lesson(
            command.Dto.Title,
            command.Dto.Description);

        var result = await _dbContext.Lessons.AddAsync(newLessonModel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        var dto = _mapper.Map<LessonDto>(result.Entity);
        return dto;
    }
}