namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Designation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TeacherId { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
