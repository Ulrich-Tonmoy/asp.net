using LeaveManagement.Application.IRepository.Generic;
using LeaveManagement.Domain;

namespace LeaveManagement.Application.IRepository
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestDetails(Guid id);
        Task<List<LeaveRequest>> GetAllLeaveRequestDetails();
    }
}
