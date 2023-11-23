using Domain.Lessons;
using Domain.Lessons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(lesson => lesson.Id);
        builder.HasIndex(lesson => lesson.Id).IsUnique();
        // Название занятия
        builder
            .Property(lesson => lesson.Title)
            .IsRequired()
            .HasMaxLength(250);
        // Описание занятия
        builder
            .Property(lesson => lesson.Description)
            .HasMaxLength(500);
        // Статус
        builder.Property(lesson => lesson.Status)
            .IsRequired();
    }
}