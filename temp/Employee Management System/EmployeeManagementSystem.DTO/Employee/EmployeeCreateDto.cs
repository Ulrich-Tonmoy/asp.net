namespace EmployeeManagementSystem.DTO.Employee
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ReportToEmpId { get; set; }
        public string ImagePath { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
