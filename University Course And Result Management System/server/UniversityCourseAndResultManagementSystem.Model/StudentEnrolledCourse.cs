namespace UniversityCourseAndResultManagementSystem.Model
{
    public class StudentEnrolledCourse
    {
        public Guid Id { get; set; }
        public EnrolledCourse EnrolledCourse { get; set; }
        public Guid EnrolledCourseId { get; set; }
        public Student Student { get; set; }
        public Guid StudentId { get; set; }
    }
}
