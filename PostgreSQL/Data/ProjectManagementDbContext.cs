using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Data;

public sealed class ProjectManagementDbContext : DbContext
{
    public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
        : base(options)
    {

    }

    public DbSet<AssignmentEntity> Assignments { get; set; }

    public DbSet<CommentEntity> Comments { get; set; }

    public DbSet<ProjectEntity> Projects { get; set; }

    public DbSet<TaskEntity> Tasks { get; set; }

    public DbSet<UserEntity> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
