namespace eCommerce.Application.DTOs.Cart
{
    public class Checkout
    {
        public Guid PaymentMethodId { get; set; }
        public IEnumerable<ProcessCart> Carts { get; set; }
    }
}
