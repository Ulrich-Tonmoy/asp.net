namespace UniversityCourseAndResultManagementSystem.DTO.StudentDto
{
    public class StudentCreateDto
    {
        public string RegiNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
