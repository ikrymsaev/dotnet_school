using Application.Common.Exceptions;
using Application.Features.Lessons.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Queries;

/* Получить занятие по Id */
public record GetLessonQuery(long Id) : IRequest<LessonDto?>;

public class GetLessonHandler : IRequestHandler<GetLessonQuery, LessonDto?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLessonHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LessonDto?> Handle(GetLessonQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons.FirstOrDefaultAsync(
            lesson => lesson.Id == request.Id, cancellationToken);
        if (entity is null) return null;

        var dto = _mapper.Map<LessonDto>(entity);
        return dto;
    }
}