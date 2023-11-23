using Domain.Common.Interfaces;

namespace Domain.Lessons.Entities;

/// <summary>
/// TODO Конструктор статьи
/// </summary>
public class Article : BaseEntity
{
    public string Text { get; set; }
}