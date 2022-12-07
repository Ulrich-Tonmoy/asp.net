namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Guid DesignationId { get; set; }
        public Guid DepartmentId { get; set; }
        public int CreditToBeTaken { get; set; }
        public int CreditTaken { get; set; }
        public Guid AssignedCourseId { get; set; }
    }
}
