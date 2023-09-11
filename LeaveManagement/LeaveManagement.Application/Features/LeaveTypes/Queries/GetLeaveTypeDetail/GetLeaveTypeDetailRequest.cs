using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetail
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public Guid Id { get; set; }
    }
}
