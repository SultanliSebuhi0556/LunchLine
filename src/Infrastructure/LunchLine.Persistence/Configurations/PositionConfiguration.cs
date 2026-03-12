using LunchLine.Domain.Entities;
using LunchLine.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunchLine.Persistence.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasData(
            new Position
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),
                Name = "Admin",
                Role = Role.Admin,
                CreatedAt = DateTime.MinValue
            });
    }
}