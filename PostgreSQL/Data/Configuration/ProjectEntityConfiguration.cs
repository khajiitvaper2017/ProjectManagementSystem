using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Data.Configuration;

public sealed class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description);

        builder.Property(e => e.EndDate);

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.StartDate);

        builder.HasMany(e => e.Tasks)
            .WithOne(e => e.Project)
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}