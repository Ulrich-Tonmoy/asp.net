namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Semester
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public List<Course> Courses { get; set; }
    }
}
