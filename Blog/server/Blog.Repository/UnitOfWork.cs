using Blog.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _blogContext;

        public ICategoryRepository CategoryRepository { get; set; }

        public UnitOfWork(
            DbContext blogContext,
            ICategoryRepository categoryRepository
            )
        {
            _blogContext = blogContext;
            CategoryRepository = categoryRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _blogContext.SaveChangesAsync();
        }
    }
}
