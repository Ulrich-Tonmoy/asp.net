namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomNo { get; set; }
        public Guid ScheduleId { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
