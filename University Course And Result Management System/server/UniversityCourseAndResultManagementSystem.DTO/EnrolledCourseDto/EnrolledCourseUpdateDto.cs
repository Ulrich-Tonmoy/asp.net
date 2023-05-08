namespace UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto
{
    public class EnrolledCourseUpdateDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentErolledCourseId { get; set; }
        public string Grade { get; set; }
    }
}
