using Application.Features.Lessons.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Lessons.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Queries;

public record GetLessonsListQuery() : IRequest<List<LessonVm>>;

public class GetLessonsListQueryHandler : IRequestHandler<GetLessonsListQuery, List<LessonVm>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLessonsListQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<LessonVm>> Handle(GetLessonsListQuery request, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.Lessons.ToListAsync(cancellationToken);
        var lessonsList = _mapper.Map<List<Lesson>, List<LessonVm>>(entities);
        
        return lessonsList;
    }
}