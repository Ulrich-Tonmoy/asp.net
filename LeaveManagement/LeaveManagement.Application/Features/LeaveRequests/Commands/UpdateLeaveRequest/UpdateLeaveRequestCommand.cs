using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }
    }
}
