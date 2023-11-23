using Domain.Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(course => course.Id);
        builder.HasIndex(course => course.Id).IsUnique();
        // Название курса
        builder
            .Property(course => course.Title)
            .IsRequired()
            .HasMaxLength(250);
        // Описание курса
        builder
            .Property(course => course.Description)
            .HasMaxLength(500);
        // Статус
        builder.Property(course => course.Status)
            .IsRequired();
    }
}