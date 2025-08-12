using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Category
{
    public class UpdateCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}
