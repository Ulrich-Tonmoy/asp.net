using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext blogContext) : base(blogContext) { }
    }
}
