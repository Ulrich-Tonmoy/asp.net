using EmployeeManagementSystem.Repository.Repositories.Contracts;

namespace EmployeeManagementSystem.Repository.Contracts
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        IDepartmentRepository DepartmentRepository { get; set; }
        IJobRepository JobRepository { get; set; }

        Task<int> SaveAsync();

    }
}
