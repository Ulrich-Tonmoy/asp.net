using Blog.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _blogContext;

        public ICategoryRepository CategoryRepository { get; set; }
        public IPostRepository PostRepository { get; set; }
        public ISubscriptionRepository SubscriptionRepository { get; set; }

        public UnitOfWork(
            DbContext blogContext,
            ICategoryRepository categoryRepository,
            IPostRepository postRepository,
            ISubscriptionRepository subscriptionRepository
            )
        {
            _blogContext = blogContext;
            CategoryRepository = categoryRepository;
            PostRepository = postRepository;
            SubscriptionRepository = subscriptionRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _blogContext.SaveChangesAsync();
        }
    }
}
