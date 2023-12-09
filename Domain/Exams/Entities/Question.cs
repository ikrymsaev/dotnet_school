using Domain.Common.Interfaces;

namespace Domain.Exams.Entities;

/// <summary>
/// Модель вопроса по тесту
/// </summary>
public class Question : BaseEntity
{
    // Текст или в последствии объект типа "статьи"
    public string Body { get; set; }
    // Изображение для вопроса
    public Guid Image { get; set; }
    
    // Идентификатор теста
    public long ExamId { get; set; }
    // Many to One relationship with Answers
    public List<Answer> Answers { get; set; }
}