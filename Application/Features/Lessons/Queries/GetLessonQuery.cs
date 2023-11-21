using Application.Common.Exceptions;
using Application.Features.Lessons.Commands.Dto;
using Application.Features.Lessons.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Queries;

/* Получить занятие по Id */
public record GetLessonQuery(long Id) : IRequest<LessonInfoVm?>;

public class GetLessonHandler : IRequestHandler<GetLessonQuery, LessonInfoVm?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLessonHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LessonInfoVm?> Handle(GetLessonQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons
            .Where(x => x.Id == request.Id)
            .Include(x => x.Tags)
            .FirstOrDefaultAsync(cancellationToken);
        if (entity is null) return null;

        var dto = _mapper.Map<LessonInfoVm>(entity);
        return dto;
    }
}