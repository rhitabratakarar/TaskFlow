using Microsoft.EntityFrameworkCore;
using TaskFlow.Interfaces;
using TaskFlow.Models;

namespace TaskFlow.Db;

public class DatabaseContext : DbContext
{
    public DbSet<WorkItem> WorkItems { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WorkItem>().Property(e => e.Id).ValueGeneratedOnAdd();
    }
}