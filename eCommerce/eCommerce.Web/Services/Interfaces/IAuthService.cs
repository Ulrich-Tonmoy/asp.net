using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Auth;

namespace eCommerce.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse> CreateUser(CreateUser user);
        Task<LoginResponse> LoginUser(LoginUser user);
        Task<LoginResponse> RefreshToken(string refreshToken);
    }
}
