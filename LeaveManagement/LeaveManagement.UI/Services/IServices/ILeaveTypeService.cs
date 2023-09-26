using LeaveManagement.UI.DTOs.LeaveType;

namespace LeaveManagement.UI.Services.IServices
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeDto>> GetAllLeaveType();
        Task<LeaveTypeDto> GetLeaveTypeById(Guid id);
        Task<LeaveTypeDto> CreateLeaveType(CreateLeaveTypeDto leaveType);
        Task<bool> DeleteLeaveType(int id);
        Task<LeaveTypeDto> UpdateLeaveType(LeaveTypeDto leaveType);
    }
}
