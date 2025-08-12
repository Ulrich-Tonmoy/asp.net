using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces.Category;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories.Category
{
    public class CategoryRepository(AppDbContext context) : ICategory
    {
        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            var products = await context.Products.Include(x => x.Category).Where(x => x.CategoryId == categoryId).AsNoTracking().ToListAsync();

            return products.Count > 0 ? products : [];
        }
    }
}
