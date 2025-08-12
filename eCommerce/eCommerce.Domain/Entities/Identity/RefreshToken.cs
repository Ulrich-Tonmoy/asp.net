namespace eCommerce.Domain.Entities.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
