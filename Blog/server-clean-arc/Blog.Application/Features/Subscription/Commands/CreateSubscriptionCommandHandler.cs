using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.SubscriptionCommands
{
    public class CreateSubscriptionCommand : IRequest<CreateSubscriptionResponseDto>
    {
        public CreateSubscriptionDto CreateSubscriptionDto { get; set; }
    }

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, CreateSubscriptionResponseDto>
    {
        private readonly ISubscriptionRepository _subRepository;
        private readonly IMapper _mapper;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subRepository, IMapper mapper)
        {
            _subRepository = subRepository;
            _mapper = mapper;
        }

        public async Task<CreateSubscriptionResponseDto> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription sub = _mapper.Map<Subscription>(request.CreateSubscriptionDto);
            sub.CreatedAt = DateTime.Now;
            sub = await _subRepository.Create(sub);
            CreateSubscriptionResponseDto createdSub = _mapper.Map<CreateSubscriptionResponseDto>(sub);

            return createdSub;
        }
    }
}
