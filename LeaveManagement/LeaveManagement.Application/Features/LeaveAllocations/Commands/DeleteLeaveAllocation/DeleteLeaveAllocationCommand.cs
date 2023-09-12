using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
