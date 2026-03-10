using LunchLine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunchLine.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.Name).IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Surname).IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Email).IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber).IsRequired()
            .HasMaxLength(15);

        builder.HasOne(x => x.Position)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Salary)
            .HasPrecision(18, 2);

        builder.Property(x => x.MounthlyTips)
            .HasPrecision(18, 2);

        builder.Property(x => x.TotalTips)
            .HasPrecision(18, 2);
    }
}