﻿using MediatR;

namespace Application.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommand : IRequest<int>
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

