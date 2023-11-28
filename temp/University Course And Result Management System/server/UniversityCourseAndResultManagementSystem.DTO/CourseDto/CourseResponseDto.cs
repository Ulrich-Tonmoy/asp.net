using UniversityCourseAndResultManagementSystem.Model;

namespace UniversityCourseAndResultManagementSystem.DTO.CourseDto
{
    public class CourseResponseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Credit { get; set; }
        public string Description { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public List<SemesterCourse> SemesterCourse { get; set; }
        public List<Schedule> Schedules { get; set; }
        public AssignedCourse AssignedCourse { get; set; }
        public EnrolledCourse EnrolledCourse { get; set; }
    }
}
