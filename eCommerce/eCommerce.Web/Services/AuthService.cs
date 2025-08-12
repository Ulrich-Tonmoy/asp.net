using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Auth;
using eCommerce.Web.Helper;
using eCommerce.Web.Services.Interfaces;
using System.Web;

namespace eCommerce.Web.Services
{
    public class AuthService(IHttpClientHelper httpClientHelper, IApiRequestHelper apiRequestHelper) : IAuthService
    {
        public async Task<ServiceResponse> CreateUser(CreateUser user)
        {

            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Auth.Register,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = user
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<CreateUser>(apiRequest);
            return result == null ? apiRequestHelper.ConnectionError() : await apiRequestHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<LoginResponse> LoginUser(LoginUser user)
        {
            var client = await httpClientHelper.GetPrivateClientAsync();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Auth.Login,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = user
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<LoginUser>(apiRequest);
            return result == null ? new LoginResponse(Message: apiRequestHelper.ConnectionError().Message) : await apiRequestHelper.GetServiceResponse<LoginResponse>(result);
        }

        public async Task<LoginResponse> RefreshToken(string refreshToken)
        {
            var client = httpClientHelper.GetPublicClient();
            var apiRequest = new ApiRequest
            {
                Route = Constant.Auth.RefreshToken,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Id = HttpUtility.UrlEncode(refreshToken),
                Model = null!
            };

            var result = await apiRequestHelper.ApiRequestTypeCall<EmptyDTO>(apiRequest);
            return result == null ? new LoginResponse(Message: apiRequestHelper.ConnectionError().Message) : await apiRequestHelper.GetServiceResponse<LoginResponse>(result);
        }
    }
}
