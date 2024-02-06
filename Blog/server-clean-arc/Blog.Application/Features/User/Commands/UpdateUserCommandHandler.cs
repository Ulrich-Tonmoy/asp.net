using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.UserCommands
{
    public class UpdateUserCommand : IRequest<UpdateUserResponseDto>
    {
        public UpdateUserDto UpdateUserDto { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _userRepository.GetByCondition(u => u.Id.Equals(request.UpdateUserDto.Id)).FirstOrDefault();
            _mapper.Map(request.UpdateUserDto, user);
            user.LastModifiedDate = DateTime.UtcNow;
            await _userRepository.Update(user);
            UpdateUserResponseDto updatedUser = _mapper.Map<UpdateUserResponseDto>(user);
            return updatedUser;
        }
    }
}
