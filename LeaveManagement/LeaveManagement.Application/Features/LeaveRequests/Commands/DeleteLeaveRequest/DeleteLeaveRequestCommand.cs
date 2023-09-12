using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
