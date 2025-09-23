using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudyPlusBack.Models;

public partial class StudyPlusContext : DbContext
{
    public StudyPlusContext()
    {
    }

    public StudyPlusContext(DbContextOptions<StudyPlusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Inscription> Inscriptions { get; set; }

    public virtual DbSet<Lection> Lections { get; set; }

    public virtual DbSet<LectionProgress> LectionProgresses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GAJEH5U\\SQLEXPRESS; Database=StudyPlus; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07FE9D62D6");

            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imgUrl");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscript__3214EC07E824B57D");

            entity.Property(e => e.Progress).HasColumnName("progress");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Course).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_CourseI");

            entity.HasOne(d => d.User).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_UserI");
        });

        modelBuilder.Entity<Lection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lections__3214EC07F8466D54");

            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Lorder).HasColumnName("LOrder");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Lections)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_CourseL");
        });

        modelBuilder.Entity<LectionProgress>(entity =>
        {
            entity.ToTable("LectionProgress");

            entity.Property(e => e.Completed).HasColumnName("completed");

            entity.HasOne(d => d.Inscription).WithMany(p => p.LectionProgresses)
                .HasForeignKey(d => d.InscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InscriptionLP");

            entity.HasOne(d => d.Lection).WithMany(p => p.LectionProgresses)
                .HasForeignKey(d => d.LectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LectionLP");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC0704676679");

            entity.HasIndex(e => e.Email, "UQ__users__A9D105341FD7FED7").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
