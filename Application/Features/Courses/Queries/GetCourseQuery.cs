using Application.Features.Courses.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries;

public record GetCourseQuery(long Id) : IRequest<CourseInfoVm?>;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseInfoVm?>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCourseQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<CourseInfoVm?> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Courses
            .Where(x => x.Id == request.Id)
            .Include(x => x.Lessons)
            .FirstOrDefaultAsync(cancellationToken);
        if (entity is null) return null;

        var dto = _mapper.Map<CourseInfoVm>(entity);
        return dto;
    }
}