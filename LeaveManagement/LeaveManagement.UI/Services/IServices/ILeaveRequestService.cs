using LeaveManagement.UI.DTOs.LeaveRequest;

namespace LeaveManagement.UI.Services.IServices
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestDto>> GetAllLeaveRequest();
        Task<LeaveRequestDto> GetLeaveRequestById(Guid id);
        Task<Response<Guid>> CreateLeaveRequest(LeaveRequestDto leaverequest);
        Task<Response<Guid>> DeleteLeaveRequest(Guid id);
        Task<Response<Guid>> UpdateLeaveRequest(LeaveRequestDto leaverequest);
    }
}
