using Domain.Courses;
using Domain.Lessons;

namespace Domain.Users;

public class Teacher : User
{
    public List<Course> Courses { get; set; }
    public List<Lesson> Lessons { get; set; }
}