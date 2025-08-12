using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Base64Image { get; set; }
        public int Quantity { get; set; }

        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
