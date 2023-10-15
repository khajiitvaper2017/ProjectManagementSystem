using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = PostgreSQL.Data.Entity.Task;
namespace PostgreSQL.Data.Configuration;

public sealed class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description);

        builder.Property(e => e.EndDate);

        builder.Property(e => e.ProjectId);

        builder.Property(e => e.StartDate);

        builder.Property(e => e.Status)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.HasOne(d => d.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(d => d.ProjectId);
    }
}