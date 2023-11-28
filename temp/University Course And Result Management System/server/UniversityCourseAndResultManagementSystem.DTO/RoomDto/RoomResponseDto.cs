using UniversityCourseAndResultManagementSystem.Model;

namespace UniversityCourseAndResultManagementSystem.DTO.RoomDto
{
    public class RoomResponseDto
    {
        public Guid Id { get; set; }
        public string RoomNo { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
