namespace Blog.Application.DTOs
{
    public class UserLoginResponseDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
