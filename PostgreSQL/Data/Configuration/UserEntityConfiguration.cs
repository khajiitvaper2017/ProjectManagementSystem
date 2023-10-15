﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Data.Entity;

namespace PostgreSQL.Data.Configuration;

public sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("UserID");

        builder.Property(e => e.Email)
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Phone)
            .HasMaxLength(20)
            .IsUnicode(false);
    }
}