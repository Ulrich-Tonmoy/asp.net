using AutoMapper;
using eCommerce.Application.DTOs.Cart;
using eCommerce.Application.Services.Interfaces.Cart;
using eCommerce.Domain.Interfaces.Cart;

namespace eCommerce.Application.Services.Cart
{
    public class PaymentMethodService(IPaymentMethod paymentMethod, IMapper mapper) : IPaymentMethodService
    {
        public async Task<IEnumerable<GetPaymentMethod>> GetPaymentMethods()
        {
            var methods = await paymentMethod.GetPaymentMethod();
            if (!methods.Any()) return [];

            return mapper.Map<IEnumerable<GetPaymentMethod>>(methods);
        }
    }
}
