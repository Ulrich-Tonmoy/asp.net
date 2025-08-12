using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eCommerce.Web.Helper.Auth
{
    public class AuthStateProvider(ITokenService tokenService) : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new(new ClaimsPrincipal());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                string jwt = await tokenService.GetJWTTokenAsync(Constant.Cookie.Name);
                if (string.IsNullOrEmpty(jwt))
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claims = GetClaims(jwt);
                if (!claims.Any())
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimPrincipal));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public void NotifyAuthenticationState()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        }

        private static IEnumerable<Claim> GetClaims(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims.ToList();
        }
    }
}
