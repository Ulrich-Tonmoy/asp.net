using Blog.DTO.UserDTO;

namespace Blog.Service.Contracts
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUserAsync();
        Task<UserResponseDTO> GetUserByIdAsync(Guid id);
        Task<UserResponseDTO> RegisterUserAsync(UserRegistrationDTO user);
        Task<UserResponseDTO> LogUserAsync(UserLoginDTO user, string secret);
        Task<UserResponseDTO> UpdateUserAsync(UserUpdateDTO user);
        Task<string> DeleteUserAsync(Guid id);
        Task<bool> AnyUserAsync(string email);
        Task<int> CountAllUserAsync();
    }
}
