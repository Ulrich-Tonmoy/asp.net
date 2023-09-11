using AutoMapper;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Guid>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            LeaveAllocation leaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Create(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
