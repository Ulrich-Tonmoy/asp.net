using Blog.Application.IRepository;
using MediatR;

namespace Blog.Application.Features.SubscriptionQueries
{
    public class GetSubscriptionExistRequest : IRequest<bool>
    {
        public string Email { get; set; }
    }

    public class GetSubscriptionExistRequestHandler : IRequestHandler<GetSubscriptionExistRequest, bool>
    {
        private readonly ISubscriptionRepository _subRepository;

        public GetSubscriptionExistRequestHandler(ISubscriptionRepository subRepository)
        {
            _subRepository = subRepository;
        }

        public async Task<bool> Handle(GetSubscriptionExistRequest request, CancellationToken cancellationToken)
        {
            bool exist = await _subRepository.Exists(c => c.Id.Equals(request.Email));
            return exist;
        }
    }
}
