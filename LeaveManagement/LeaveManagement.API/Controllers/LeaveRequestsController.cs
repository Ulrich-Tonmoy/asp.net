using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail;
using LeaveManagement.Application.Features.LeaveRequests.Queries.GetLeaveRequestList;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            List<LeaveRequestDto> leaveAllocations = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveAllocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(Guid id)
        {
            LeaveRequestDto leaveAllocation = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id }); ;
            return Ok(leaveAllocation);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto };
            Guid response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, UpdateLeaveRequestDto = updateLeaveRequestDto };
            Unit response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            Unit response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
