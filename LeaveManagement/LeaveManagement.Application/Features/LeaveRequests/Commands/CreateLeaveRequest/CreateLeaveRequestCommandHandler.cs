using AutoMapper;
using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Guid>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            LeaveRequest leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Create(leaveRequest);

            return leaveRequest.Id;
        }
    }
}
