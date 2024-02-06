using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.PostCommands
{
    public class UpdatePostCommand : IRequest<UpdatePostResponseDto>
    {
        public UpdatePostDto UpdatePostDto { get; set; }
    }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostResponseDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePostResponseDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _postRepository.GetByCondition(c => c.Id.Equals(request.UpdatePostDto.Id)).FirstOrDefault();
            _mapper.Map(request.UpdatePostDto, post);
            post.LastModifiedDate = DateTime.UtcNow;
            await _postRepository.Update(post);
            UpdatePostResponseDto updatedPost = _mapper.Map<UpdatePostResponseDto>(post);
            return updatedPost;
        }
    }
}
