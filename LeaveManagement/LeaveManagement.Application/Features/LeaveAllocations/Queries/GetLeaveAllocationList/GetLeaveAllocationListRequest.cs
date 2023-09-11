using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationList
{
    public class GetLeaveAllocationListRequest : IRequest<LeaveAllocationDto>
    {
        public Guid Id { get; set; }
    }
}
