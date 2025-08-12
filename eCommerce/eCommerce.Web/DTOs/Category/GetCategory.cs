using eCommerce.Web.DTOs.Product;

namespace eCommerce.Web.DTOs.Category
{
    public class GetCategory : CategoryBase
    {
        public Guid Id { get; set; }
        public ICollection<GetProduct>? Products { get; set; }
    }
}
