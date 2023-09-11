using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : IRequest<Guid>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
