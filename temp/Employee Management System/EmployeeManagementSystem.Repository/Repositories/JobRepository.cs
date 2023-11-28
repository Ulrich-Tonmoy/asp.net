using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Repositories
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(DbContext employeeManagementSystemContext) : base(employeeManagementSystemContext)
        {

        }
    }
}
