using Domain.Common.Interfaces;

namespace Domain.Exams.Entities;

/// <summary>
/// Модель ответа на вопрос теста
/// </summary>
public class Answer : BaseEntity
{
    // Текст ответа
    public string Body { get; set; }
    // Изображение ответа
    public Guid? Image { get; set; }
    // Флаг правильности ответа
    public bool IsCorrect { get; set; }
    // One to Many relationship with Question
    public long QuestionId { get; set; }
}