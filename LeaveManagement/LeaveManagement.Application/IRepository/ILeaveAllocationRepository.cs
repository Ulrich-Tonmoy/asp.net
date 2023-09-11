using LeaveManagement.Application.IRepository.Generic;
using LeaveManagement.Domain;

namespace LeaveManagement.Application.IRepository
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationDetails(Guid id);
        Task<List<LeaveAllocation>> GetAllLeaveAllocationDetails();
    }
}
