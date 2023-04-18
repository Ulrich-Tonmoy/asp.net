using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EMS.Model;

namespace WiredBrainCoffee.EMS.Data
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}