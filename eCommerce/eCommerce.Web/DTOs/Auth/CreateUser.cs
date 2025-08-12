using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Auth
{
    public class CreateUser : AuthBase
    {
        [Required]
        public string? FullName { get; set; }
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
