namespace LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
