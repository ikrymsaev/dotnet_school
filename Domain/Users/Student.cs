using Domain.Courses.Entities;

namespace Domain.Users;

public class Student : User
{
    public List<Course> Courses { get; set; }
}