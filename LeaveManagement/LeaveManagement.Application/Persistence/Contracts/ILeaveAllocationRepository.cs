using LeaveManagement.Domain;

namespace LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationDetails(Guid id);
        Task<List<LeaveAllocation>> GetAllLeaveAllocationDetails();
    }
}
