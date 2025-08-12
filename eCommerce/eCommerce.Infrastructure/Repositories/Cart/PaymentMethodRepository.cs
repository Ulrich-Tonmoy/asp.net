using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Interfaces.Cart;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories.Cart
{
    public class PaymentMethodRepository(AppDbContext context) : IPaymentMethod
    {
        public async Task<IEnumerable<PaymentMehtod>> GetPaymentMethod()
        {
            return await context.PaymentMehtods.AsNoTracking().ToListAsync();
        }
    }
}
