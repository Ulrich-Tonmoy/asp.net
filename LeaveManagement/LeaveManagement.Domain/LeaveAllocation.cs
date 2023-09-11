using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
