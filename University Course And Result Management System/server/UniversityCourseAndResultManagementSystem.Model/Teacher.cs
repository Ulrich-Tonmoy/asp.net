namespace UniversityCourseAndResultManagementSystem.Model
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Designation Designation { get; set; }
        public Guid DesignationId { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public float CreditToBeTaken { get; set; }
        public float CreditTaken { get; set; }
        public List<AssignedCourse> AssignedCourses { get; set; }
    }
}
