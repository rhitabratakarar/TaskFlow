using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.Db;

public class DatabaseContext : DbContext
{
    public DbSet<WorkItem> WorkItems { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
}