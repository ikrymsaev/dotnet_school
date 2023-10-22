using Application.Features.Tags.Dto;
using FluentValidation;

namespace Application.Features.Tags.Validations;

/// <summary>
/// Валидатор создания тэга
/// </summary>
public class CreateTagValidator : AbstractValidator<CreateTagDto>
{
    public CreateTagValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(2)
            .MaximumLength(20);
        RuleFor(x => x.Color)
            .Matches("^#(?:[0-9a-fA-F]{3}){1,2}$")
            .WithMessage("Must be a HEX type #000000");
    }
}