using Blog.Application.DTOs;
using Blog.Application.Features.UserCommands;
using Blog.Application.Features.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserResponseDto>>> GetAllUser()
        {
            List<GetUserResponseDto> users = await _mediator.Send(new GetUserListRequest());
            return Ok(new { data = users });
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetUserResponseDto user = await _mediator.Send(new GetUserDetailRequest { Id = id });
            return Ok(new { data = user });
        }

        [HttpPost("registration")]
        public async Task<IActionResult> UserRegistration([FromBody] UserRegistrationDto user)
        {
            var command = new UserRegistrationCommand { UserRegistrationDto = user };
            UserRegistrationResponseDto response = await _mediator.Send(command);
            return CreatedAtRoute("UserById", new { id = response.Id }, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDto user)
        {
            var command = new UserLoginCommand { UserLoginDto = user };
            command.UserLoginDto.Secret = _configuration.GetSection("AppSettings:Secret").Value!;
            UserLoginResponseDto response = await _mediator.Send(command);
            return Ok(new { data = response });
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto user)
        {
            var command = new UpdateUserCommand { UpdateUserDto = user };
            UpdateUserResponseDto response = await _mediator.Send(command);
            return Ok(new { data = response });
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
