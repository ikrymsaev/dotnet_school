using Domain.Users;

namespace Domain.Lessons;

/// <summary>
/// Занятие, включает в себя материалы и задания для выполнения.
/// </summary>
public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<LessonTag> Tags { get; set; }
    // Создатель занятия.
    public Teacher Creator { get; set; }
    // Контент занятия.
    public Article Content { get; set; }
    // Список тестов.
    public List<Test> Tests { get; set; }
    // Список домашних заданий.
    public List<HomeWork> HomeWorks { get; set; }
    // Проверяет на завершение всех тестов и заданий.
    public Boolean GetIsCompleted()
    {
        var testCompleted = Tests.TrueForAll(work => work.IsCompleted);
        var worksCompleted = HomeWorks.TrueForAll(work => work.IsCompleted);

        return testCompleted && worksCompleted;
    }
}