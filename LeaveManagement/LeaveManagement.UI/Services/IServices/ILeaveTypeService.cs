using LeaveManagement.UI.DTOs.LeaveType;

namespace LeaveManagement.UI.Services.IServices
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeDto>> GetAllLeaveType();
        Task<LeaveTypeDto> GetLeaveTypeById(Guid id);
        Task CreateLeaveType(CreateLeaveTypeDto leaveType);
        Task<bool> DeleteLeaveType(Guid id);
        Task UpdateLeaveType(LeaveTypeDto leaveType);
    }
}
