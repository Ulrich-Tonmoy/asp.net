using Blog.Common.QueryParameters;
using Blog.DTO.PostDTO;

namespace Blog.Service.Contracts
{
    public interface IPostService
    {
        Task<List<PostResponseDTO>> GetAllPostAsync(PostQueryParameters queryParams);
        Task<PostResponseDTO> GetPostByIdAsync(Guid id);
        Task<PostResponseDTO> CreatePostAsync(PostCreateDTO post);
        Task<PostResponseDTO> UpdatePostAsync(PostUpdateDTO post);
        Task<string> DeletePostAsync(Guid id);
        Task<bool> AnyPostAsync(string title);
        Task<int> CountAllPostAsync();
    }
}
