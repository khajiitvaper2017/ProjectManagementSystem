using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Data.Configuration;

public sealed class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
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