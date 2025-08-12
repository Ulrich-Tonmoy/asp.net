
using NetcodeHub.Packages.WebAssembly.Storage.Cookie;

namespace eCommerce.Web.Helper
{
    public class TokenService(IBrowserCookieStorageService cookieService) : ITokenService
    {
        public string FormToken(string jwt, string refresh)
        {
            return $"{jwt}--{refresh}";
        }

        public async Task<string> GetJWTTokenAsync(string key)
        {
            return await GetTokenAsync(key, 0);
        }

        private async Task<string> GetTokenAsync(string key, int position)
        {
            try
            {
                string token = await cookieService.GetAsync(key);
                return token != null ? token.Split("--")[position] : null!;
            }
            catch
            {
                return null!;
            }
        }

        public async Task<string> GetRefreshTokenAsync(string key)
        {
            return await GetTokenAsync(key, 1);
        }

        public async Task RemoveCookies(string key)
        {
            await cookieService.RemoveAsync(key);
        }

        public async Task SetCookies(string key, string value, int days, string path)
        {
            await cookieService.SetAsync(key, value, days, path);
        }
    }
}
