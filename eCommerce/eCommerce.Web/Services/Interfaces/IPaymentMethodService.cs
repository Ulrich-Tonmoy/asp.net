using eCommerce.Web.DTOs.Cart;

namespace eCommerce.Web.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods();
    }
}
