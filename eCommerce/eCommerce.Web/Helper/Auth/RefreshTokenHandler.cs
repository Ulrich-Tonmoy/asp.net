using eCommerce.Web.DTOs;
using eCommerce.Web.Helper;
using eCommerce.Web.Services.Interfaces;

namespace eCommerce.Web.Helper.Auth
{
    public class RefreshTokenHandler(ITokenService tokenService, IAuthService authService, IHttpClientHelper httpClientHelper) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isPost = request.Method.Equals("POST");
            bool isPut = request.Method.Equals("PUT");
            bool isDelete = request.Method.Equals("DELETE");

            var result = await base.SendAsync(request, cancellationToken);

            if (isPost || isPut || isDelete)
            {
                if (result.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                    return result;

                var refreshToken = await tokenService.GetRefreshTokenAsync(Constant.Cookie.Name);
                if (string.IsNullOrEmpty(refreshToken))
                    return result;

                var loginResponse = await GetAndSetRefreshToken(refreshToken);
                if (loginResponse == null)
                    return result;

                await httpClientHelper.GetPrivateClientAsync();
                return await base.SendAsync(request, cancellationToken);
            }
            return result;
        }

        private async Task<LoginResponse> GetAndSetRefreshToken(string refreshToken)
        {
            var result = await authService.RefreshToken(refreshToken);

            if (result.Success)
            {
                string cookie = tokenService.FormToken(result.Token, result.RefreshToken);
                await tokenService.RemoveCookies(Constant.Cookie.Name);
                await tokenService.SetCookies(Constant.Cookie.Name, cookie, Constant.Cookie.Days, Constant.Cookie.Path);

                return result;
            }
            return null!;
        }
    }
}
