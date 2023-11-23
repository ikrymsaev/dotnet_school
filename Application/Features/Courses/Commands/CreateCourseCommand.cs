using Application.Features.Courses.Commands.Dto;
using Application.Features.Courses.Queries.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Courses.Entities;
using MediatR;

namespace Application.Features.Courses.Commands;

public record CreateCourseCommand(CreateCourseDto CreateDto) : IRequest<CourseVm>;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCourseCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<CourseVm> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
    {
        var dto = command.CreateDto;
        var newCourse = new Course(dto.Title, dto.Description ?? "");
        var result = await _dbContext.Courses.AddAsync(newCourse, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var courseVm = _mapper.Map<CourseVm>(result.Entity);

        return courseVm;
    }
}