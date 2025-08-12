using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Product
{
    public class ProductBase
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Base64Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
