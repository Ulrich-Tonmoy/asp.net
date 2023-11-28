using EmployeeManagementSystem.Data.Context;
using EmployeeManagementSystem.Repository.Contracts;
using EmployeeManagementSystem.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _employeeManagementSystemContext;
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IJobRepository JobRepository { get; set; }

        public UnitOfWork(
            DbContext employeeManagementSystemContext,
            IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository,
            IJobRepository jobRepository)
        {
            _employeeManagementSystemContext = employeeManagementSystemContext;
            DepartmentRepository = departmentRepository;
            EmployeeRepository = employeeRepository;
            JobRepository = jobRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _employeeManagementSystemContext.SaveChangesAsync();
        }
    }
}
