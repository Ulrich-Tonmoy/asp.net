using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext employeeManagementSystemContext) : base(employeeManagementSystemContext)
        {

        }
    }
}
