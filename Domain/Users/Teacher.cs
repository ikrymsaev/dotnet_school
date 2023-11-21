using Domain.Courses.Entities;
using Domain.Lessons;
using Domain.Lessons.Entities;

namespace Domain.Users;

public class Teacher : User
{
    public List<Course> Courses { get; set; }
    public List<Lesson> Lessons { get; set; }
}