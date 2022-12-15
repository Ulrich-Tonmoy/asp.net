namespace UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto
{
    public class AssignCourseCreateDto
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid CourseId { get; set; }
    }
}
