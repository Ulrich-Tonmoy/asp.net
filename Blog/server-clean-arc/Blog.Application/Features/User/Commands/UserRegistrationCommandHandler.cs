using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.UserCommands
{
    public class UserRegistrationCommand : IRequest<UserRegistrationResponseDto>
    {
        public UserRegistrationDto UserRegistrationDto { get; set; }
    }

    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, UserRegistrationResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserRegistrationCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserRegistrationResponseDto> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request.UserRegistrationDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedAt = DateTime.UtcNow;
            await _userRepository.Create(user);
            UserRegistrationResponseDto createdUser = _mapper.Map<UserRegistrationResponseDto>(user);
            return createdUser;
        }
    }
}
