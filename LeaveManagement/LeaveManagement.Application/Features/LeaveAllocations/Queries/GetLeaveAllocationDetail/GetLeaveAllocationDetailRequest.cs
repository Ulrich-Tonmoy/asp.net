using LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationDetail
{
    public class GetLeaveAllocationDetailRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
