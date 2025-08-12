namespace eCommerce.Web.Helper
{
    public interface ITokenService
    {
        Task<string> GetJWTTokenAsync(string key);
        Task<string> GetRefreshTokenAsync(string key);
        string FormToken(string jwt, string refresh);
        Task SetCookies(string key, string value, int days, string path);
        Task RemoveCookies(string key);
    }
}
