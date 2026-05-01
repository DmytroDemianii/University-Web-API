using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.Models.Entities;

namespace UniversityWebAPI.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        private string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSES");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("COURSE_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUPS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("GROUP_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnName("NAME");
                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");
                entity.Property(e => e.TeacherId).HasColumnName("TEACHER_ID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENTS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("STUDENT_ID")
                      .ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasColumnName("FIRST_NAME");
                entity.Property(e => e.LastName).HasColumnName("LAST_NAME");
                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHERS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("TEACHER_ID").ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasColumnName("FIRST_NAME");
                entity.Property(e => e.LastName).HasColumnName("LAST_NAME");
            });

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Teacher)
                .WithMany(t => t.Groups)
                .HasForeignKey(g => g.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}