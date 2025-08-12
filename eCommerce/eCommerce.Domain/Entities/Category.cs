using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
