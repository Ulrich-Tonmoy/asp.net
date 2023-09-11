using LeaveManagement.Domain;

namespace LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestDetails(Guid id);
        Task<List<LeaveRequest>> GetAllLeaveRequestDetails();
    }
}
