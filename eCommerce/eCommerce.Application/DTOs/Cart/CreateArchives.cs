namespace eCommerce.Application.DTOs.Cart
{
    public class CreateArchives
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string? UserId { get; set; }
    }
}
