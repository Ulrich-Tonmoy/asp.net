using Blog.Application.IRepository;
using Blog.Application.QueryParams;
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

        public async Task<IReadOnlyList<Post>> GetAllPost(PostQueryParameters queryParams)
        {
            IQueryable<Post> query = _dbContext.Posts;

            if (queryParams.IsFeatured != null)
                query = query.Where(post => post.IsFeatured == queryParams.IsFeatured);

            if (queryParams.IdNotEqual != Guid.Empty)
                query = query.Where(post => post.Id != queryParams.IdNotEqual);

            if (queryParams.CategoryId != Guid.Empty)
                query = query.Where(post => post.CategoryId == queryParams.CategoryId);

            if (!string.IsNullOrEmpty(queryParams.SortBy) && !string.IsNullOrEmpty(queryParams.OrderBy))
            {
                if (queryParams.SortBy.ToLower() == "createdat")
                {
                    if (queryParams.OrderBy.ToLower() == "desc")
                        query = query.OrderByDescending(post => post.CreatedAt);
                    else
                        query = query.OrderBy(post => post.CreatedAt);
                }
            }

            query = query.Take(queryParams.Limit);
            List<Post> posts = await query.Include(p => p.Category).ToListAsync();

            return posts;
        }

        public async Task<Post> GetById(Guid id)
        {
            return await _dbContext.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
