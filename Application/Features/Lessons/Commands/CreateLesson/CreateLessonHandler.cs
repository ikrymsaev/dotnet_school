﻿using Application.Interfaces;
using Domain.Lessons;
using MediatR;

namespace Application.Features.Lessons.Commands.CreateLesson;

public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, long>
{
    private readonly IAppDbContext _dbContext;

    public CreateLessonHandler(IAppDbContext dbContext) {
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine(dbContext);
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        _dbContext = dbContext;
    }
    
    public async Task<long> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = new Lesson
        {
            Id = 1,
            Title = request.Title,
            Description = request.Description
        };
        await _dbContext.Lessons.AddAsync(lesson, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return lesson.Id;
    }
}