using System.ComponentModel.DataAnnotations;

namespace WiredBrainCoffee.EMS.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;
        public bool IsDeveloper { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}