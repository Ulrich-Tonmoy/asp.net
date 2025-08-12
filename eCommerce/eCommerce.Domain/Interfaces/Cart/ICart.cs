using eCommerce.Domain.Entities.Cart;

namespace eCommerce.Domain.Interfaces.Cart
{
    public interface ICart
    {
        Task<int> SaveCheckoutHistory(IEnumerable<Archive> checkouts);
        Task<IEnumerable<Archive>> GetAllCheckoutHistory();
    }
}
