using LunchLine.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunchLine.Persistence.Configurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Floor).IsRequired();

        builder.Property(x => x.SeatCount).IsRequired();

        builder.Property(x => x.Section).IsRequired().HasMaxLength(25);
    }
}