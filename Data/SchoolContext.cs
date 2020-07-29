using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Enrollment>(s => s.Enrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(ad => ad.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany<Enrollment>(s => s.Enrollments)
                .WithOne(s => s.Course)
                .HasForeignKey(ad => ad.CourseID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
