using Domain.Common;
using Domain.Common.Interfaces;
using Domain.Users;

namespace Domain.Lessons;

/// <summary>
/// Занятие, включает в себя материалы и задания для выполнения.
/// </summary>
public class Lesson : BaseEntity
{
    public Lesson(string title, string description)
    {
        Title = title;
        Description = description;
        CreatedAt = new DateTime();
    }

    public string Title { get; set; }
    public string Description { get; set; }
    // Теги для фильтрации.
    public List<Tag>? Tags { get; } = new();
    // Создатель занятия.
    public Teacher? Creator { get; set; }
    // Контент занятия.
    public Article? Content { get; set; }
    // Список тестов.
    public List<Test>? Tests { get; set; }
    // Список домашних заданий.
    public List<HomeWork>? HomeWorks { get; set; }
    // Проверяет на завершение всех тестов и заданий.
    public bool GetIsCompleted()
    {
        var testCompleted = Tests.TrueForAll(work => work.IsCompleted);
        var worksCompleted = HomeWorks.TrueForAll(work => work.IsCompleted);

        return testCompleted && worksCompleted;
    }
}