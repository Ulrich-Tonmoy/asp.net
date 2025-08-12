namespace eCommerce.Application.DTOs.Identity
{
    public class CreateUser : UserBase
    {
        public required string Fullname { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
