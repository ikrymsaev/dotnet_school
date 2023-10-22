using Application.Features.Lessons.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Queries;

public record GetLessonsListQuery() : IRequest<List<LessonDto>>;

public class GetLessonsListQueryHandler : IRequestHandler<GetLessonsListQuery, List<LessonDto>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLessonsListQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<LessonDto>> Handle(GetLessonsListQuery request, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.Lessons.ToListAsync(cancellationToken);
        var lessonsList = _mapper.Map<List<Lesson>, List<LessonDto>>(entities);
        
        return lessonsList;
    }
}