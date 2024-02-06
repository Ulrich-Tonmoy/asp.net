using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;

namespace Blog.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext blogContext) : base(blogContext) { }
    }
}
