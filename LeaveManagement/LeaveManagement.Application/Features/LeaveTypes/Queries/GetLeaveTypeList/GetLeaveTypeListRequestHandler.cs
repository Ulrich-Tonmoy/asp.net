using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.IRepository;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeList
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<LeaveType> leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}
