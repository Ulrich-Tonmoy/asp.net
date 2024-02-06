using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;

namespace Blog.Infrastructure.Repository
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(BlogDbContext blogContext) : base(blogContext) { }
    }
}
