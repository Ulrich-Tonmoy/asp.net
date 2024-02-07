using Blog.Application.DTOs;
using Blog.Application.Features.PostCommands;
using Blog.Application.Features.PostQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            List<GetPostResponseDto> response = await _mediator.Send(new GetPostListRequest());
            return Ok(new { data = response });
        }

        [HttpGet("{id}", Name = "PostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            GetPostResponseDto response = await _mediator.Send(new GetPostDetailRequest { Id = id });
            return Ok(new { data = response });
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto post)
        {
            var command = new CreatePostCommand { CreatePostDto = post };
            CreatePostResponseDto response = await _mediator.Send(command);
            return CreatedAtRoute("PostById", new { id = response.Id }, response);
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto post)
        {
            var command = new UpdatePostCommand { UpdatePostDto = post };
            UpdatePostResponseDto response = await _mediator.Send(command);
            return Ok(new { data = response });
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePostCommand { Id = id };
            Unit response = await _mediator.Send(command);
            return Ok(new { data = response });
        }
    }
}
