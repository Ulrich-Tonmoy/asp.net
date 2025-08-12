using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Interfaces.Cart;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories.Cart
{
    public class CartRepository(AppDbContext context) : ICart
    {
        public async Task<IEnumerable<Archive>> GetAllCheckoutHistory()
        {
            return await context.CheckoutArchives.AsNoTracking().ToListAsync();
        }

        public async Task<int> SaveCheckoutHistory(IEnumerable<Archive> checkouts)
        {
            context.CheckoutArchives.AddRange(checkouts);
            return await context.SaveChangesAsync();
        }
    }
}
