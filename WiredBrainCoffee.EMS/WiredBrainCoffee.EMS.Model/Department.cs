using System.ComponentModel.DataAnnotations;

namespace WiredBrainCoffee.EMS.Model
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; }
    }
}
