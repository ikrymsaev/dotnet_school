using Domain.Common.Interfaces;
using Domain.Courses.ValueObjects;
using Domain.Lessons;
using Domain.Lessons.Entities;
using Domain.Users;

namespace Domain.Courses.Entities;

// Курс, объединяет в себе набор занятий.
public class Course : BaseEntity
{
    public Course(string title, string description)
    {
        Title = title;
        Description = description;
        Status = ECourseStatus.Draft;
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Lesson> Lessons { get; } = new();
    
    // Статус
    public ECourseStatus Status { get; set; }
    
    public string? AvatarUri { get; set; }
    public Article? Content { get; set; }
    // Создатель курса
    public Teacher? Creator { get; set; }
    // Список студентов
    public List<Student>? Students { get; set; }

    public ECourseStatus ChangeStatus(ECourseStatus newStatus)
    {
        Status = newStatus;
        return Status;
    }
}