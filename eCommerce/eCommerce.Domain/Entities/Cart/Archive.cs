using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Entities.Cart
{
    public class Archive
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
