using UniversityCourseAndResultManagementSystem.Model;

namespace UniversityCourseAndResultManagementSystem.DTO.DesignationDto
{
    public class DesignationResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
