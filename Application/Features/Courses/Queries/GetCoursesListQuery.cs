using Application.Features.Courses.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Courses.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries;

public record GetCoursesListQuery() : IRequest<List<CourseVm>>;

public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<CourseVm>>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCoursesListQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CourseVm>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.Courses
            .Include(x => x.Lessons)
            .ToListAsync(cancellationToken);
        var lessonsList = _mapper.Map<List<Course>, List<CourseVm>>(entities);
        
        return lessonsList;
    }
}