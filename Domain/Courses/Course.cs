﻿using Domain.Common.Enums;
using Domain.Common.Interfaces;
using Domain.Lessons;
using Domain.Users;

namespace Domain.Courses;

// Курс, объединяет в себе набор занятий.
public class Course : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string AvatarUri { get; set; }
    public Article Content { get; set; }
    // Создатель курса
    public Teacher Creator { get; set; }
    // Список студентов
    public List<Student> Students { get; set; }
    // Список уроков
    public List<Lesson> Lessons { get; set; }
    // Статус
    public ECourseStatus Status { get; set; }

    public Course(ECourseStatus status = ECourseStatus.Draft)
    {
        Status = status;
    }
    
    // Проверяет статус выполнения всех занятий
    public Boolean GetIsCompleted()
    {
        return Lessons.TrueForAll(lesson => lesson.GetIsCompleted());
    }
}