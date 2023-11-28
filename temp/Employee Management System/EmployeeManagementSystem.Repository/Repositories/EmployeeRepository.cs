using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext employeeManagementSystemContext) : base(employeeManagementSystemContext)
        {

        }
    }
}
