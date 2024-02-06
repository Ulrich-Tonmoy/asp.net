using Blog.Domain.Common;

namespace Blog.Domain
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
