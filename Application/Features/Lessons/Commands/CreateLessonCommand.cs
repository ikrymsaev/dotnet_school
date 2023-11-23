using Application.Features.Lessons.Commands.Dto;
using Application.Features.Lessons.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons;
using Domain.Lessons.Entities;
using MediatR;

namespace Application.Features.Lessons.Commands;

public record CreateLessonCommand(CreateLessonDto Dto) : IRequest<LessonVm>;

// Обработчик создания нового занятия.
public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, LessonVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateLessonCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LessonVm> Handle(CreateLessonCommand command, CancellationToken cancellationToken)
    {
        var newLessonModel = new Lesson(
            command.Dto.Title,
            command.Dto.Description);

        var result = await _dbContext.Lessons.AddAsync(newLessonModel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        var dto = _mapper.Map<LessonVm>(result.Entity);
        return dto;
    }
}