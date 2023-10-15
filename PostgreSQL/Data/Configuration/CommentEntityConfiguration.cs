using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Data.Configuration;

public sealed class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Date);

        builder.Property(e => e.Text);

        builder.Property(e => e.TaskId);

        builder.Property(e => e.UserId);

        builder.HasOne(d => d.Task)
            .WithMany(p => p.Comments)
            .HasForeignKey(d => d.TaskId);

        builder.HasOne(d => d.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(d => d.UserId);
    }
}