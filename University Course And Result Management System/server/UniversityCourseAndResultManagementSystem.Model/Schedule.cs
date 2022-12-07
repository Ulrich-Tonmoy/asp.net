namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string Day { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Guid CourseId { get; set; }
    }
}
