using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext blogContext) : base(blogContext) { }
    }
}
