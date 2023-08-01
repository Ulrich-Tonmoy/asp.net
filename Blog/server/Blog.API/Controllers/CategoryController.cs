using Blog.Common;
using Blog.DTO.CategoryDTO;
using Blog.Service.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                List<CategoryResponseDTO> categoriesResult = await _categoryService.GetAllCategoryAsync();

                return Ok(new { data = categoriesResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            try
            {
                CategoryResponseDTO categoryResult = await _categoryService.GetCategoryByIdAsync(id);

                if (categoryResult == null) return NotFound();

                return Ok(new { data = categoryResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDTO category)
        {
            try
            {
                if (category == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "Category"));

                bool exist = await _categoryService.AnyCategoryAsync(category.Name);
                if (exist) return BadRequest(String.Format(GlobalConstants.OBJECT_EXIST, "Category", "Name"));

                CategoryResponseDTO createdCategory = await _categoryService.CreateCategoryAsync(category);

                return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);

            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDTO category)
        {
            try
            {
                if (category == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "Category"));

                CategoryResponseDTO categoryEntity = await _categoryService.UpdateCategoryAsync(category);
                if (categoryEntity == null) return NotFound();

                return Ok(new { data = categoryEntity });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                string category = await _categoryService.DeleteCategoryAsync(id);
                if (category == null) return NotFound();

                return Ok(new { data = category });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> AnyCategoryExist([FromQuery] string categoryName)
        {
            try
            {
                var catExist = await _categoryService.AnyCategoryAsync(categoryName);

                return Ok(new { data = catExist });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> CategoryCount()
        {
            try
            {
                var categoryCount = await _categoryService.CountAllCategoryAsync();

                return Ok(new { data = categoryCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
