namespace UniversityCourseAndResultManagementSystem.DTO.EnrolledCourseDto
{
    public class EnrolledCourseCreateDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public string? Grade { get; set; }
    }
}
