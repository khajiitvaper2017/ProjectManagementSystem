using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data.Entity;
using Task = PostgreSQL.Data.Entity.Task;

namespace PostgreSQL.Data;

public sealed class ProjectManagementDbContext : DbContext
{
    public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Assignment> Assignments { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
