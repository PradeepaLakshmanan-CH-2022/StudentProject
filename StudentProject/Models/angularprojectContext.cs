using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentProject.Models
{
    public partial class angularprojectContext : DbContext
    {
        public angularprojectContext()
        {
        }

        public angularprojectContext(DbContextOptions<angularprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<UserRegister> UserRegisters { get; set; } = null!;
        public virtual DbSet<Userlogin> Userlogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=angularproject;User Id=sa;Password=Pass#1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Course)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentPercentage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Student_Percentage");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Student__Departm__38996AB5");
            });

            modelBuilder.Entity<UserRegister>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRegi__1788CC4C97364341");

                entity.ToTable("UserRegister");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Userlogi__1788CC4C81DB19F6");

                entity.ToTable("Userlogin");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
