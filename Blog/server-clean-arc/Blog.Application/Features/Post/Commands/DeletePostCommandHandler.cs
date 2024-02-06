using AutoMapper;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.PostCommands
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _postRepository.GetByCondition(p => p.Id.Equals(request.Id)).FirstOrDefault();
            await _postRepository.Delete(post);

            return Unit.Value;
        }
    }
}
