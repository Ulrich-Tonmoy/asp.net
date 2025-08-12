using eCommerce.Application.DTOs.Identity;
using eCommerce.Application.Services.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticationService authenticationService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUser user)
        {
            var result = await authenticationService.CreateUser(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUser user)
        {
            var result = await authenticationService.LoginUser(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("refresh-token/${refreshToken}")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var result = await authenticationService.RefreshToken(HttpUtility.UrlDecode(refreshToken));
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
