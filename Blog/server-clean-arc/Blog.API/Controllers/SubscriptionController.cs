using Blog.Application.DTOs;
using Blog.Application.Features.SubscriptionCommands;
using Blog.Application.Features.SubscriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscription()
        {
            List<GetSubscriptionResponseDto> response = await _mediator.Send(new GetSubscriptionListRequest());
            return Ok(new { data = response });
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionDto sub)
        {
            var command = new CreateSubscriptionCommand { CreateSubscriptionDto = sub };
            CreateSubscriptionResponseDto response = await _mediator.Send(command);
            return Ok(new { data = response });
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            var command = new DeleteSubscriptionCommand { Id = id };
            Unit response = await _mediator.Send(command);
            return Ok(new { data = response });
        }

        [HttpGet("any")]
        public async Task<IActionResult> AnySubscriptionExist([FromQuery] string email)
        {
            var command = new GetSubscriptionExistRequest { Email = email };
            bool response = await _mediator.Send(command);

            return Ok(new { data = response });
        }
    }
}
