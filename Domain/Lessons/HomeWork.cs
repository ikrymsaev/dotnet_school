namespace Domain.Lessons;

/// <summary>
/// Домашнее задание по итогам прохождения занятия.
/// </summary>
public class HomeWork
{
    public int Id { get; set; }
    // Текстовое описание домашнего задания
    public string Task { get; set; }
    // Состояние выполения (переключает препод)
    public Boolean IsCompleted { get; set; }
    // Отчет о выполении со стороны студента
    public string Report { get; set; }
}