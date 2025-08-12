using eCommerce.Application.DTOs.Category;
using eCommerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _categoryService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _categoryService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategory category)
        {
            var result = await _categoryService.AddAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateCategory category)
        {
            var result = await _categoryService.UpdateAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("products-by-category/{id}")]
        public async Task<IActionResult> GetProductsByCategory(Guid id)
        {
            var data = await _categoryService.GetProductsByCategory(id);
            return data.Any() ? Ok(data) : NotFound(data);
        }
    }
}
