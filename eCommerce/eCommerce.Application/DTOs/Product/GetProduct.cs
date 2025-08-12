using eCommerce.Application.DTOs.Category;

namespace eCommerce.Application.DTOs.Product
{
    public class GetProduct : ProductBase
    {
        public Guid Id { get; set; }
        public GetCategory? Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
