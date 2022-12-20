namespace UniversityCourseAndResultManagementSystem.Model
{
    public class SemesterCourse
    {
        public Guid Id { get; set; }
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
        public Semester Semester { get; set; }
        public Guid SemesterId { get; set; }
    }
}
