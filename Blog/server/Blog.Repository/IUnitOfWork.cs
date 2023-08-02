using Blog.Repository.Repositories.Contracts;

namespace Blog.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        IPostRepository PostRepository { get; set; }
        public ISubscriptionRepository SubscriptionRepository { get; set; }

        Task<int> SaveAsync();
    }
}
