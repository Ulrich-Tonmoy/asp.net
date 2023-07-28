using Blog.Repository.Repositories.Contracts;

namespace Blog.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }

        Task<int> SaveAsync();
    }
}
