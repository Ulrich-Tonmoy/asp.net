using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationList
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            LeaveAllocation leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationDetails(request.Id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}
