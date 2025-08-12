using eCommerce.Web.DTOs;
using eCommerce.Web.DTOs.Cart;

namespace eCommerce.Web.Services.Interfaces
{
    public interface ICartService
    {
        Task<ServiceResponse> Checkout(Checkout checkout);
        Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateAchieve> archives);
        Task<IEnumerable<GetArchive>> GetArchives();
    }
}
