using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Category;
using eCommerce.Web.DTOs.Product;

namespace eCommerce.Web.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId);
    }
}
