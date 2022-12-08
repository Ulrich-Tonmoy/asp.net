namespace UniversityCourseAndResultManagementSystem.Model
{
    public class AssignedCourse
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
