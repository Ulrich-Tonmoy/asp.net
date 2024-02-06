using Blog.Domain.Common;

namespace Blog.Domain
{
    public class User : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
