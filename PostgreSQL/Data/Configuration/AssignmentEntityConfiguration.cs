using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Data.Configuration;

public sealed class AssignmentEntityConfiguration : IEntityTypeConfiguration<AssignmentEntity>
{
    public void Configure(EntityTypeBuilder<AssignmentEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Date);

        builder.Property(e => e.TaskId);

        builder.Property(e => e.UserId);

        builder.HasOne(d => d.Task)
            .WithMany(p => p.Assignments)
            .HasForeignKey(d => d.TaskId);

        builder.HasOne(d => d.User)
            .WithMany(p => p.Assignments)
            .HasForeignKey(d => d.UserId);
    }
}