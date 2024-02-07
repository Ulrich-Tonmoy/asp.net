using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.PostQueries
{
    public class GetPostListRequest : IRequest<List<GetPostResponseDto>>
    {
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
            IReadOnlyList<Post> posts = await _postRepository.GetAllPost();
            return _mapper.Map<List<GetPostResponseDto>>(posts);
        }
    }
}
