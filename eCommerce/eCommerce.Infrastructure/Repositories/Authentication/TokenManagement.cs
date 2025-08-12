using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eCommerce.Infrastructure.Repositories.Authentication
{
    public class TokenManagement(AppDbContext context, IConfiguration config) : ITokenManagement
    {
        public async Task<int> AddRefreshToken(string userId, string refreshToken)
        {
            context.RefreshToken.Add(new RefreshToken
            {
                UserId = userId,
                Token = refreshToken
            });
            return await context.SaveChangesAsync();
        }

        public string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetRefreshToken()
        {
            const int byteSize = 64;
            byte[] randomBytes = new byte[byteSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            string token = Convert.ToBase64String(randomBytes);
            return WebUtility.UrlEncode(token);
        }

        public List<Claim> GetUserClaimsFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            if (jwtToken != null)
                return jwtToken.Claims.ToList();
            return [];
        }

        public async Task<string> GetUserIdByRefreshToken(string refreshToken) => (await context.RefreshToken.FirstOrDefaultAsync(x => x.Token == refreshToken))!.UserId;

        public async Task<int> UpdateRefreshToken(string userId, string refreshToken)
        {
            var user = await context.RefreshToken.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null) return -1;
            user.Token = refreshToken;
            return await context.SaveChangesAsync();
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken)
        {
            var user = await context.RefreshToken.FirstOrDefaultAsync(x => x.Token == refreshToken);
            return user != null;
        }

        public async Task<bool> ValidateRefreshTokenById(string id)
        {
            var user = await context.RefreshToken.FirstOrDefaultAsync(x => x.UserId == id);
            return user != null;
        }
    }
}
