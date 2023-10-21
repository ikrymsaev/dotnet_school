using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(tag => tag.Id);
        builder.HasIndex(tag => tag.Id)
            .IsUnique();
        builder.Property(tag => tag.Color)
            .HasMaxLength(10);
        builder.Property(tag => tag.Title)
            .IsRequired()
            .HasMaxLength(50);
    }
}