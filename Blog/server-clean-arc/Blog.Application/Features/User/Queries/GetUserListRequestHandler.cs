using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.UserQueries
{
    public class GetUserListRequest : IRequest<List<GetUserResponseDto>>
    {
    }

    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<GetUserResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserResponseDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<User> users = await _userRepository.GetAll();
            return _mapper.Map<List<GetUserResponseDto>>(users);
        }
    }
}
