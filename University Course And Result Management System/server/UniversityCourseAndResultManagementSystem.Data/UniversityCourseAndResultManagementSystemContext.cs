using Microsoft.EntityFrameworkCore;
using UniversityCourseAndResultManagementSystem.Model;

namespace UniversityCourseAndResultManagementSystem.Data
{
    public class UniversityCourseAndResultManagementSystemContext : DbContext
    {
        public UniversityCourseAndResultManagementSystemContext(DbContextOptions<UniversityCourseAndResultManagementSystemContext> options) : base(options) { }

        public DbSet<AssignedCourse> AssignedCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EnrolledCourse> EnrolledCourses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
