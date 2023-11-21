using Domain.Common.Interfaces;

namespace Domain.Lessons.Entities;

/// <summary>
/// Тест по итогам прохождения занятия.
/// </summary>
public class Test : BaseEntity
{
    // TODO Возможно будет не просто текст а на основе конструктора.
    public string Question { get; set; }
    // TODO Возможны варианты ввиде картинок или более сложное пердставление.
    public List<string> Variants { get; set; }
    public List<string> CorrectAnswers { get; set; }

    public Boolean IsCompleted { get; set; }
}