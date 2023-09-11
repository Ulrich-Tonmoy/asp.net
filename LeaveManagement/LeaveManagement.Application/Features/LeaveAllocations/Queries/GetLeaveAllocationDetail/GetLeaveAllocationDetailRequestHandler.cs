using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocationDetail
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<LeaveAllocation> leaveAllocation = await _leaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
        }
    }
}
