using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebApi.Models;

namespace WebApi.Contexts;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TaskItem> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("PRIMARY");

            entity.ToTable("project");

            entity.HasIndex(e => e.IdAdmin, "fk_project_admin_idx");

            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("fk_project_admin");

            entity.HasMany(d => d.IdUsers).WithMany(p => p.IdProjects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectHasUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("fk_user_has_project_user"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("IdProject")
                        .HasConstraintName("fk_user_has_project_project"),
                    j =>
                    {
                        j.HasKey("IdProject", "IdUser")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("project_has_user");
                        j.HasIndex(new[] { "IdProject" }, "fk_user_has_project_project_idx");
                        j.HasIndex(new[] { "IdUser" }, "fk_user_has_project_user_idx");
                        j.IndexerProperty<int>("IdProject").HasColumnName("id_project");
                        j.IndexerProperty<int>("IdUser").HasColumnName("id_user");
                    });
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.IdProject, "fk_task_project_idx");

            entity.HasIndex(e => e.IdUser, "fk_task_user_idx");

            entity.Property(e => e.IdTask).HasColumnName("id_task");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'queue'")
                .HasColumnType("enum('queue','progress','hold','complete')")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasColumnName("title");

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdProject)
                .HasConstraintName("fk_task_project");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_task_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .HasColumnName("image_path");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
