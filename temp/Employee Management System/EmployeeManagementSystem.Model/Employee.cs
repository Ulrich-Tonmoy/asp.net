using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ReportToEmpId { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("EmployeeModel")]
        public Guid JobTitleId { get; set; }
        [ForeignKey("DepartmentModel")]
        public Guid DepartmentId { get; set; }
    }
}
