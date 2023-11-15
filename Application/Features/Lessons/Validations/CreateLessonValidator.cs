﻿using Application.Features.Lessons.Dto;
using FluentValidation;

namespace Application.Features.Lessons.Validations;

public class CreateLessonValidator : AbstractValidator<CreateLessonDto>
{
    public CreateLessonValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(250);
        RuleFor(x => x.Description).MaximumLength(500);
    }
}