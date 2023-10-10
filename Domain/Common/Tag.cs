using Domain.Common.Interfaces;
using Domain.Lessons;

namespace Domain.Common;

public class Tag : BaseEntity
{
    public string Title { get; set; }
    public string Color { get; set; }

    public List<Lesson> Lessons { get; } = new();
}