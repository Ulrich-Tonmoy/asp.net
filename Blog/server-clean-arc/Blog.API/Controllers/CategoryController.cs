using Blog.Application.DTOs;
using Blog.Application.Features.CategoryCommands;
using Blog.Application.Features.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            List<GetCategoryResponseDto> response = await _mediator.Send(new GetCategoryListRequest());
            return Ok(new { data = response });
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            GetCategoryResponseDto response = await _mediator.Send(new GetCategoryDetailRequest { Id = id });
            return Ok(new { data = response });
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto category)
        {
            var command = new CreateCategoryCommand { CreateCategoryDto = category };
            CreateCategoryResponseDto response = await _mediator.Send(command);
            return CreatedAtRoute("CategoryById", new { id = response.Id }, response);
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto category)
        {
            var command = new UpdateCategoryCommand { UpdateCategoryDto = category };
            UpdateCategoryResponseDto response = await _mediator.Send(command);
            return Ok(new { data = response });
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            Unit response = await _mediator.Send(command);
            return Ok(new { data = response });
        }
    }
}
