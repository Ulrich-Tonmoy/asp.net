using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Cart
{
    public class CreateAchieve : ProcessCart
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
