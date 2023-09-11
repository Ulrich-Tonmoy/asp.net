using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommand : IRequest<Guid>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
