using Blog.Common;
using Blog.DTO.UserDTO;
using Blog.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<UserResponseDTO> userssResult = await _userService.GetAllUserAsync();

                return Ok(new { data = userssResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                UserResponseDTO userResult = await _userService.GetUserByIdAsync(id);

                if (userResult == null) return NotFound();

                return Ok(new { data = userResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDTO user)
        {
            try
            {
                if (user == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "User"));

                bool exist = await _userService.AnyUserAsync(user.Email);
                if (exist) return BadRequest(String.Format(GlobalConstants.OBJECT_EXIST, "User", "Email"));

                UserResponseDTO createdUser = await _userService.RegisterUserAsync(user);

                return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);

            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogUser([FromBody] UserLoginDTO user)
        {
            try
            {
                if (user == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "User"));
                bool exist = await _userService.AnyUserAsync(user.Email);
                if (!exist) return BadRequest(String.Format(GlobalConstants.OBJECT_DOESNOT_EXIST, "User"));

                UserResponseDTO loggedUser = await _userService.LogUserAsync(user, _configuration.GetSection("AppSettings:Token").Value!);
                if (loggedUser == null) return BadRequest(String.Format(GlobalConstants.WRONG_PASSWORD));

                return Ok(new { data = loggedUser });

            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPatch, Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO user)
        {
            try
            {
                if (user == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "User"));

                UserResponseDTO userEntity = await _userService.UpdateUserAsync(user);
                if (userEntity == null) return NotFound();

                return Ok(new { data = userEntity });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                string user = await _userService.DeleteUserAsync(id);
                if (user == null) return NotFound();

                return Ok(new { data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> AnyUserExist([FromQuery] string email)
        {
            try
            {
                var catExist = await _userService.AnyUserAsync(email);

                return Ok(new { data = catExist });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> CategoryCount()
        {
            try
            {
                var userCount = await _userService.CountAllUserAsync();

                return Ok(new { data = userCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
