using LunchLine.Domain.Entities;
using LunchLine.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;

namespace LunchLine.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}