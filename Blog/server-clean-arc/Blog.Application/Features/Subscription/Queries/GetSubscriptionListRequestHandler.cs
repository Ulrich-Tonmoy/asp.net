using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.SubscriptionQueries
{
    public class GetSubscriptionListRequest : IRequest<List<GetSubscriptionResponseDto>>
    {
    }

    public class GetSubscriptionListRequestHandler : IRequestHandler<GetSubscriptionListRequest, List<GetSubscriptionResponseDto>>
    {
        private readonly ISubscriptionRepository _subRepository;
        private readonly IMapper _mapper;

        public GetSubscriptionListRequestHandler(ISubscriptionRepository subRepository, IMapper mapper)
        {
            _subRepository = subRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSubscriptionResponseDto>> Handle(GetSubscriptionListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Subscription> subs = await _subRepository.GetAll();
            return _mapper.Map<List<GetSubscriptionResponseDto>>(subs);
        }
    }
}
