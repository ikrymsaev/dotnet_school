using Application.Interfaces;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Lessons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Queries;

public class GetLessonHandler : IRequestHandler<GetLessonQuery, LessonVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLessonHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<LessonVm> Handle(GetLessonQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons.FirstOrDefaultAsync(
            lesson => lesson.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Lesson), request.Id);
        }

        return _mapper.Map<LessonVm>(entity);
    }
}