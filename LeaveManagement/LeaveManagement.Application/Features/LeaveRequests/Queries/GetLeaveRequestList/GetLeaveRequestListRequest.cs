using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestList
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestDto>>
    {
    }
}
