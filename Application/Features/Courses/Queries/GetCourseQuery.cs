using Application.Features.Courses.ViewModel;
using Application.Features.Lessons.Dto;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries;

public record GetCourseQuery(long Id) : IRequest<CourseVm>;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCourseQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<CourseVm> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Courses.FirstOrDefaultAsync(
            course => course.Id == request.Id, cancellationToken);
        if (entity is null) return null;

        var dto = _mapper.Map<CourseVm>(entity);
        return dto;
    }
}