using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.UserQueries
{
    public class GetUserDetailRequest : IRequest<GetUserResponseDto>
    {
        public Guid Id { get; set; }
    }

    public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, GetUserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserResponseDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            User user = _userRepository.GetByCondition(u => u.Id.Equals(request.Id)).FirstOrDefault();
            return _mapper.Map<GetUserResponseDto>(user);
        }
    }
}
