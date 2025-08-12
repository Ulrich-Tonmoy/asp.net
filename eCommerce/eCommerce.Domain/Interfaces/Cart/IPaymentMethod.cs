using eCommerce.Domain.Entities.Cart;

namespace eCommerce.Domain.Interfaces.Cart
{
    public interface IPaymentMethod
    {
        Task<IEnumerable<PaymentMehtod>> GetPaymentMethod();
    }
}
