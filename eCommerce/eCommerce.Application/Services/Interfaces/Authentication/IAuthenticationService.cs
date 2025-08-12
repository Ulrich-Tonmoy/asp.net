using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Identity;

namespace eCommerce.Application.Services.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> CreateUser(CreateUser user);
        Task<LoginResponse> LoginUser(LoginUser user);
        Task<LoginResponse> RefreshToken(string refreshToken);
    }
}
