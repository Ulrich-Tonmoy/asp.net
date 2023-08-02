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
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(
            DbContext blogContext,
            ICategoryRepository categoryRepository,
            IPostRepository postRepository,
            ISubscriptionRepository subscriptionRepository,
            IUserRepository userRepository
            )
        {
            _blogContext = blogContext;
            CategoryRepository = categoryRepository;
            PostRepository = postRepository;
            SubscriptionRepository = subscriptionRepository;
            UserRepository = userRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _blogContext.SaveChangesAsync();
        }
    }
}
