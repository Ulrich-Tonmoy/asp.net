using AutoMapper;
using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Guid>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            LeaveType leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
            leaveType = await _leaveTypeRepository.Create(leaveType);

            return leaveType.Id;
        }
    }
}
