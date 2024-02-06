using Blog.Domain.Common;

namespace Blog.Domain
{
    public class Subscription : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
