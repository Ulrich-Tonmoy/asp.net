using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Category
{
    public class CategoryBase
    {
        [Required]
        public string? Name { get; set; }
    }
}
