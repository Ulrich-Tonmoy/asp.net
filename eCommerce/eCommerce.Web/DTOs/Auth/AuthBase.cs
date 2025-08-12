using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.DTOs.Auth
{
    public class AuthBase
    {
        [EmailAddress, Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
