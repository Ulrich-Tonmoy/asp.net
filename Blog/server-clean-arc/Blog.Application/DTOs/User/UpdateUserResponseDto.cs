namespace Blog.Application.DTOs
{
    public class UpdateUserResponseDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
