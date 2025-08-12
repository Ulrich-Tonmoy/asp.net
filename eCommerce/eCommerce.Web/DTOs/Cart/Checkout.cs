using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Cart
{
    public class Checkout
    {
        [Required]
        public Guid PaymentMethodId { get; set; }
        [Required]
        public IEnumerable<ProcessCart> Carts { get; set; } = [];
    }
}
