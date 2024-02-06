using AutoMapper;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.SubscriptionCommands
{
    public class DeleteSubscriptionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, Unit>
    {
        private readonly ISubscriptionRepository _subRepository;
        private readonly IMapper _mapper;

        public DeleteSubscriptionCommandHandler(ISubscriptionRepository subRepository, IMapper mapper)
        {
            _subRepository = subRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription sub = _subRepository.GetByCondition(s => s.Id.Equals(request.Id)).FirstOrDefault();
            await _subRepository.Delete(sub);

            return Unit.Value;
        }
    }
}
