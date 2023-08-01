using Blog.Common;
using Blog.Common.QueryParameters;
using Blog.DTO.PostDTO;
using Blog.Model;
using Blog.Repository;
using Blog.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Service
{
    public class PostService : IPostService
    {
        private IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PostResponseDTO>> GetAllPostAsync(PostQueryParameters queryParams)
        {
            IQueryable<Post> query = _unitOfWork.PostRepository.GetAllNoTracking().Include(c => c.Category);

            if (queryParams.IsFeatured != null)
                query = query.Where(post => post.IsFeatured == queryParams.IsFeatured);

            if (queryParams.IdNotEqual != Guid.Empty)
                query = query.Where(post => post.Id != queryParams.IdNotEqual);

            if (queryParams.CategoryId != Guid.Empty)
                query = query.Where(post => post.CategoryId == queryParams.CategoryId);

            if (!string.IsNullOrEmpty(queryParams.SortBy) && !string.IsNullOrEmpty(queryParams.OrderBy))
            {
                bool isDescending = queryParams.OrderBy.ToLower() == "desc";
                switch (queryParams.SortBy.ToLower())
                {
                    case "createdat":
                        query = isDescending ? query.OrderByDescending(post => post.CreatedAt) : query.OrderBy(post => post.CreatedAt);
                        break;
                    default:
                        break;
                }
            }

            query = query.Take(queryParams.Limit);
            List<Post> posts = await query.ToListAsync();
            List<PostResponseDTO> postsResult = Mapping.Mapper.Map<List<PostResponseDTO>>(posts);

            return postsResult;
        }

        public async Task<PostResponseDTO> GetPostByIdAsync(Guid id)
        {
            Post post = _unitOfWork.PostRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).Include(c => c.Category).FirstOrDefault();
            PostResponseDTO postResult = Mapping.Mapper.Map<PostResponseDTO>(post);

            return postResult;
        }

        public async Task<PostResponseDTO> CreatePostAsync(PostCreateDTO post)
        {
            Post postModel = Mapping.Mapper.Map<Post>(post);

            await _unitOfWork.PostRepository.AddAsync(postModel);
            await _unitOfWork.SaveAsync();

            PostResponseDTO postResult = Mapping.Mapper.Map<PostResponseDTO>(postModel);

            return postResult;
        }

        public async Task<PostResponseDTO> UpdatePostAsync(PostUpdateDTO post)
        {
            Post postEntity = _unitOfWork.PostRepository.GetByConditionNoTracking(c => c.Id.Equals(post.Id)).FirstOrDefault();

            if (postEntity == null) return null;

            Mapping.Mapper.Map(post, postEntity);

            await _unitOfWork.PostRepository.Update(postEntity);
            await _unitOfWork.SaveAsync();

            PostResponseDTO postResult = Mapping.Mapper.Map<PostResponseDTO>(postEntity);

            return postResult;
        }

        public async Task<string> DeletePostAsync(Guid id)
        {
            Post post = _unitOfWork.PostRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();

            if (post == null) return null;

            await _unitOfWork.PostRepository.Delete(post);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "Post");
        }

        public async Task<bool> AnyPostAsync(string title)
        {
            return await _unitOfWork.PostRepository.AnyAsync(c => c.Title.Equals(title));
        }

        public async Task<int> CountAllPostAsync()
        {
            return await _unitOfWork.PostRepository.CountAllAsync();
        }
    }
}
