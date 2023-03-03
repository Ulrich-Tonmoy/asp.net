namespace UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto
{
    public class EnrolledCourseCreateDto
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime Date { get; set; }
        public string? Grade { get; set; }
    }
}
