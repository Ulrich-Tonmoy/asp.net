using LeaveManagement.UI.DTOs.LeaveType;

namespace LeaveManagement.UI.Services.IServices
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeDto>> GetAllLeaveType();
        Task<LeaveTypeDto> GetLeaveTypeById(Guid id);
        Task<Response<Guid>> CreateLeaveType(LeaveTypeDto leaveType);
        Task<Response<Guid>> DeleteLeaveType(Guid id);
        Task<Response<Guid>> UpdateLeaveType(LeaveTypeDto leaveType);
    }
}
