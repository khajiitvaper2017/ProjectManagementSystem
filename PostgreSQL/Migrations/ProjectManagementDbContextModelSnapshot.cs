﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PostgreSQL.Data;

#nullable disable

namespace PostgreSQL.Migrations
{
    [DbContext(typeof(ProjectManagementDbContext))]
    partial class ProjectManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PostgreSQL.Data.Entity.AssignmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("TaskId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.CommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("TaskId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("UserID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.AssignmentEntity", b =>
                {
                    b.HasOne("PostgreSQL.Data.Entity.TaskEntity", "Task")
                        .WithMany("Assignments")
                        .HasForeignKey("TaskId");

                    b.HasOne("PostgreSQL.Data.Entity.UserEntity", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("UserId");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.CommentEntity", b =>
                {
                    b.HasOne("PostgreSQL.Data.Entity.TaskEntity", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId");

                    b.HasOne("PostgreSQL.Data.Entity.UserEntity", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.TaskEntity", b =>
                {
                    b.HasOne("PostgreSQL.Data.Entity.ProjectEntity", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.ProjectEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.TaskEntity", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PostgreSQL.Data.Entity.UserEntity", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
