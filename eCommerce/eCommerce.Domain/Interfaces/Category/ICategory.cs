using eCommerce.Domain.Entities;

namespace eCommerce.Domain.Interfaces.Category
{
    public interface ICategory
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
    }
}
