using Application.Features.Courses.ViewModel;
using Application.Features.Lessons.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Courses.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Commands;

public record UpdateCourseCommand(long CourseId, CreateCourseDto Dto) : IRequest<CourseVm>;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public UpdateCourseCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CourseVm> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        if (entity is null) return null;

        entity.Title = request.Dto.Title;
        entity.Description = request.Dto.Description;
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseVm>(entity);

    }
}