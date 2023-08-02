using Blog.Common;
using Blog.DTO.UserDTO;
using Blog.Model;
using Blog.Repository;
using Blog.Service.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserResponseDTO>> GetAllUserAsync()
        {
            List<User> users = _unitOfWork.UserRepository.GetAllNoTracking().ToList();
            List<UserResponseDTO> usersResult = Mapping.Mapper.Map<List<UserResponseDTO>>(users);

            return usersResult;
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(Guid id)
        {
            User user = _unitOfWork.UserRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();
            UserResponseDTO userResult = Mapping.Mapper.Map<UserResponseDTO>(user);

            return userResult;
        }

        public async Task<UserResponseDTO> RegisterUserAsync(UserRegistrationDTO user)
        {
            User userModel = Mapping.Mapper.Map<User>(user);
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            await _unitOfWork.UserRepository.AddAsync(userModel);
            await _unitOfWork.SaveAsync();

            UserResponseDTO userResult = Mapping.Mapper.Map<UserResponseDTO>(userModel);

            return userResult;
        }

        public async Task<UserResponseDTO> LogUserAsync(UserLoginDTO user, string secret)
        {
            User userModel = _unitOfWork.UserRepository.GetByConditionNoTracking(c => c.Email.Equals(user.Email)).FirstOrDefault();

            if (!BCrypt.Net.BCrypt.Verify(user.Password, userModel.Password)) return null;

            UserResponseDTO userResult = Mapping.Mapper.Map<UserResponseDTO>(userModel);
            string token = CreateToken(userModel, secret);
            userResult.Token = token;

            return userResult;
        }

        public async Task<UserResponseDTO> UpdateUserAsync(UserUpdateDTO user)
        {
            User userEntity = _unitOfWork.UserRepository.GetByConditionNoTracking(c => c.Id.Equals(user.Id)).FirstOrDefault();

            if (userEntity == null) return null;

            Mapping.Mapper.Map(user, userEntity);

            await _unitOfWork.UserRepository.Update(userEntity);
            await _unitOfWork.SaveAsync();

            UserResponseDTO userResult = Mapping.Mapper.Map<UserResponseDTO>(userEntity);

            return userResult;
        }

        public async Task<string> DeleteUserAsync(Guid id)
        {
            User user = _unitOfWork.UserRepository.GetByConditionNoTracking(c => c.Id.Equals(id)).FirstOrDefault();

            if (user == null) return null;

            await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();

            return String.Format(GlobalConstants.SUCCESSFULLY_DELETED, "User");
        }

        public async Task<bool> AnyUserAsync(string email)
        {
            return await _unitOfWork.UserRepository.AnyAsync(c => c.Email.Equals(email));
        }

        public async Task<int> CountAllUserAsync()
        {
            return await _unitOfWork.UserRepository.CountAllAsync();
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
