using Domain.Common.Interfaces;
using Domain.Courses.Entities;
using Domain.Lessons.ValueObjects;
using Domain.Tags.Entities;
using Domain.Exams.Entities;
using Domain.Users;

namespace Domain.Lessons.Entities;

/// <summary>
/// Занятие, включает в себя материалы и задания для выполнения.
/// </summary>
public class Lesson : BaseEntity
{
    public Lesson(string title, string description)
    {
        Title = title;
        Description = description;
        CreatedAt = DateTime.Now;
        Status = ELessonStatus.Draft;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public ELessonStatus Status { get; set; }
    // Теги для фильтрации.
    public List<Tag> Tags { get; } = new();
    // Список курсов в которые включен урок.
    public List<Course> Courses { get; } = new();
    // Список тестов по итогам прохождения занятия.
    public List<Exam> Exams { get; set; }
    
    // Создатель занятия.
    public Teacher? Creator { get; set; }
    // Контент занятия.
    public Article? Content { get; set; }
    // Список домашних заданий.
    public List<HomeWork>? HomeWorks { get; set; }
    
    public ELessonStatus ChangeStatus(ELessonStatus newStatus)
    {
        Status = newStatus;
        return Status;
    }
}