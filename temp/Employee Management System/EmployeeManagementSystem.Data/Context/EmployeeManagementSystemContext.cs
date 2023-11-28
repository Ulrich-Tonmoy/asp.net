using EmployeeManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data.Context
{
    public class EmployeeManagementSystemContext : DbContext
    {
        public EmployeeManagementSystemContext(DbContextOptions<EmployeeManagementSystemContext> options) : base(options) { }

        public DbSet<Employee> EmployeeModels { get; set; }
        public DbSet<Department> DepartmentModels { get; set; }
        public DbSet<Job> JobTitleModels { get; set; }
    }
}
