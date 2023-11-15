using Domain.Lessons;
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
        // Теги занятия
        builder
            .HasMany(l => l.Tags)
            .WithMany(t => t.Lessons)
            .UsingEntity<LessonTag>();
    }
}