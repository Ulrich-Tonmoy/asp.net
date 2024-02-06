using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.PostQueries
{
    public class GetPostDetailRequest : IRequest<GetPostResponseDto>
    {
        public Guid Id { get; set; }
    }

    public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, GetPostResponseDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailRequestHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetPostResponseDto> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
        {
            Post post = _postRepository.GetByCondition(p => p.Id.Equals(request.Id)).FirstOrDefault();
            return _mapper.Map<GetPostResponseDto>(post);
        }
    }
}
