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

        builder.Property(x => x.Name)
            .IsRequired()
            .IsUnicode();

        builder.HasData(
            new Position
            {
                Id = new Guid(),
                Name = "Admin",
                Role = Role.Admin
            });
    }
}