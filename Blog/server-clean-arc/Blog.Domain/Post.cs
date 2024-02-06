using Blog.Domain.Common;

namespace Blog.Domain
{
    public class Post : BaseDomainEntity
    {
        public string Title { get; set; }
        public string PermaLink { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public string HeroImg { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public bool IsFeatured { get; set; } = false;
        public int Views { get; set; } = 0;
    }
}
