using Blog.Model;
using Blog.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext blogContext) : base(blogContext) { }
    }
}
