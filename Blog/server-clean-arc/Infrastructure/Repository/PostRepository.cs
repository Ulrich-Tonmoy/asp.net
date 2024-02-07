using Blog.Application.IRepository;
using Blog.Domain;
using Blog.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly BlogDbContext _dbContext;

        public PostRepository(BlogDbContext blogContext) : base(blogContext)
        {
            _dbContext = blogContext;
        }

        public async Task<IReadOnlyList<Post>> GetAllPost()
        {
            return await _dbContext.Posts.Include(x => x.Category).ToListAsync();
        }

        public async Task<Post> GetById(Guid id)
        {
            return await _dbContext.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
