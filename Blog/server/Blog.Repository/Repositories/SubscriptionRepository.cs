using Blog.Model;
using Blog.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Repositories
{
    public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(DbContext blogContext) : base(blogContext) { }
    }
}
