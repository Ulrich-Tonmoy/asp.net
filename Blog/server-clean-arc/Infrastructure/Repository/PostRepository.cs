using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;

namespace Blog.Infrastructure.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext blogContext) : base(blogContext) { }
    }
}
