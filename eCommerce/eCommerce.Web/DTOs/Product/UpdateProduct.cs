using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Product
{
    public class UpdateProduct : ProductBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}
