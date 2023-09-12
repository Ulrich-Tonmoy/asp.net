using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetail;
using LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            List<LeaveTypeDto> leavTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leavTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(Guid id)
        {
            LeaveTypeDto leavType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leavType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommand { CreateLeaveTypeDto = leaveType };
            Guid response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] LeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
