using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.PostCommands
{
    public class CreatePostCommand : IRequest<CreatePostResponseDto>
    {
        public CreatePostDto CreatePostDto { get; set; }
    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponseDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostResponseDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request.CreatePostDto);
            post.CreatedAt = DateTime.Now;
            post = await _postRepository.Create(post);
            CreatePostResponseDto createdPost = _mapper.Map<CreatePostResponseDto>(post);

            return createdPost;
        }
    }
}
