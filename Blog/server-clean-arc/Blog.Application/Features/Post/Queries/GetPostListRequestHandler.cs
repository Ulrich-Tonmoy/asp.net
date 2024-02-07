using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Application.QueryParams;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.PostQueries
{
    public class GetPostListRequest : IRequest<List<GetPostResponseDto>>
    {
        public PostQueryParameters queryParams { get; set; }
    }

    public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, List<GetPostResponseDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostListRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPostResponseDto>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Post> posts = await _postRepository.GetAllPost(request.queryParams);
            return _mapper.Map<List<GetPostResponseDto>>(posts);
        }
    }
}
