using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentPerformance.Entity.Models;

public partial class StudentAssgnContext : DbContext
{
    public StudentAssgnContext()
    {
    }

    public StudentAssgnContext(DbContextOptions<StudentAssgnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marksheet> Marksheets { get; set; }

    public virtual DbSet<StudentMaster> StudentMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SALONY;Initial Catalog=StudentAssgn; User Id=sa; password=root;Persist Security Info=False;Integrated Security=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marksheet>(entity =>
        {
            entity.HasKey(e => e.MarkSheetId).HasName("PK__Markshee__719B6DB26357727F");

            entity.ToTable("Marksheet");

            entity.Property(e => e.MarkSheetId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MarksObtained).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.TotalMark)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Student).WithMany(p => p.Marksheets)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marksheet__Stude__3B75D760");
        });

        modelBuilder.Entity<StudentMaster>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentM__32C52B99F9FB6C4F");

            entity.ToTable("StudentMaster");

            entity.Property(e => e.StudentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.StudentName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
