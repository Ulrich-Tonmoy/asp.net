using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.SubscriptionCommands
{
    public class UpdateSubscriptionComman : IRequest<UpdateSubscriptionResponseDto>
    {
        public UpdateSubscriptionDto UpdateSubscriptionDto { get; set; }
    }

    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionComman, UpdateSubscriptionResponseDto>
    {
        private readonly ISubscriptionRepository _subRepository;
        private readonly IMapper _mapper;

        public UpdateSubscriptionCommandHandler(ISubscriptionRepository subRepository, IMapper mapper)
        {
            _subRepository = subRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSubscriptionResponseDto> Handle(UpdateSubscriptionComman request, CancellationToken cancellationToken)
        {
            Subscription sub = _subRepository.GetByCondition(s => s.Id.Equals(request.UpdateSubscriptionDto.Id)).FirstOrDefault();
            _mapper.Map(request.UpdateSubscriptionDto, sub);
            sub.LastModifiedDate = DateTime.UtcNow;
            await _subRepository.Update(sub);
            UpdateSubscriptionResponseDto updatedSub = _mapper.Map<UpdateSubscriptionResponseDto>(sub);
            return updatedSub;
        }
    }
}
