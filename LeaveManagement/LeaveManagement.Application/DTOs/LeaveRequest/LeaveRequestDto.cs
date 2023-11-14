using LeaveManagement.Application.DTOs.Common;
using LeaveManagement.Application.DTOs.LeaveType;

namespace LeaveManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public string RequestComments { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
