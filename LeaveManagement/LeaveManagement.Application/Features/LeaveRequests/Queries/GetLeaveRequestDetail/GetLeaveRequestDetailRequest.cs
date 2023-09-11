using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
    {
        public Guid Id { get; set; }
    }
}
