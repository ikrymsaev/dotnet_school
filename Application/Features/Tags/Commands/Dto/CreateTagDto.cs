namespace Application.Features.Tags.Commands.Dto;

public class CreateTagDto
{
    public string Title { get; }
    public string Color { get; }

    public CreateTagDto(string title, string color)
    {
        Title = title;
        Color = color;
    }
}