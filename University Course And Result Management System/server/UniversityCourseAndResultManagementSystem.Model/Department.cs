namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public List<Course> Courses { get; set; }
        public Guid StudentId { get; set; }
        public List<Student> Students { get; set; }
        public Guid TeacherId { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
