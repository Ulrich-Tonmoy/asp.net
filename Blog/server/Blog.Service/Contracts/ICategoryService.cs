using Blog.DTO.Category;

namespace Blog.Service.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetAllCategoryAsync();
        Task<CategoryResponseDTO> GetCategoryByIdAsync(Guid id);
        Task<CategoryResponseDTO> CreateCategoryAsync(CategoryCreateDTO category);
        Task<CategoryResponseDTO> UpdateCategoryAsync(CategoryUpdateDTO category);
        Task<string> DeleteCategoryAsync(Guid id);
        Task<bool> AnyCategoryAsync(string name);
        Task<int> CountAllCategoryAsync();
    }
}
