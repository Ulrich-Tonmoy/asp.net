namespace UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto
{
    public class AssignedCourseCreateDto
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid CourseId { get; set; }
    }
}
