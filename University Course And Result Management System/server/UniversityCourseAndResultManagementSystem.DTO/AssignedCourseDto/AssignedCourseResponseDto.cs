using UniversityCourseAndResultManagementSystem.Model;

namespace UniversityCourseAndResultManagementSystem.DTO.AssignedCourseDto
{
    public class AssignedCourseResponseDto
    {
        public Guid Id { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
    }
}
