using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext blogContext) : base(blogContext) { }
    }
}
