using Domain.Common.Interfaces;

namespace Domain.Exams.Entities;

/// <summary>
/// Тест по итогам прохождения занятия.
/// </summary>
public class Exam : BaseEntity
{
    public long LessonId { get; set; }
    // Список вопросов
    public List<Question> Questions { get; set; }
}