using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;

namespace Blog.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BlogDbContext blogContext) : base(blogContext) { }
    }
}
