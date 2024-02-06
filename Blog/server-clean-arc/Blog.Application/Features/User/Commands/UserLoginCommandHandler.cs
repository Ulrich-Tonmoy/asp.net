using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.IRepository;
using Blog.Domain;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Application.Features.UserCommands
{
    public class UserLoginCommand : IRequest<UserLoginResponseDto>
    {
        public UserLoginDto UserLoginDto { get; set; }
    }

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserLoginCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginResponseDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            User user = _userRepository.GetByCondition(u => u.Email.Equals(request.UserLoginDto.Email)).FirstOrDefault();

            if (!BCrypt.Net.BCrypt.Verify(request.UserLoginDto.Password, user.Password)) return null;

            UserLoginResponseDto userResult = _mapper.Map<UserLoginResponseDto>(user);
            string token = CreateToken(user, request.UserLoginDto.Secret);
            userResult.Token = token;

            return userResult;
        }

        private string CreateToken(User user, string secret)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credential);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
