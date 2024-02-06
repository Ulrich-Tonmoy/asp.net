namespace Blog.Application.DTOs
{
    public class UpdateUserDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
