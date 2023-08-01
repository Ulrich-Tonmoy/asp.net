using Blog.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _blogContext;

        public ICategoryRepository CategoryRepository { get; set; }
        public IPostRepository PostRepository { get; set; }

        public UnitOfWork(
            DbContext blogContext,
            ICategoryRepository categoryRepository,
            IPostRepository postRepository
            )
        {
            _blogContext = blogContext;
            CategoryRepository = categoryRepository;
            PostRepository = postRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _blogContext.SaveChangesAsync();
        }
    }
}
