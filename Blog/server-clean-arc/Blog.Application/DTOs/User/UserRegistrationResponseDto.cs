namespace Blog.Application.DTOs
{
    public class UserRegistrationResponseDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
