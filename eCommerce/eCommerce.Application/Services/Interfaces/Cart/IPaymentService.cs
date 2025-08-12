using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Cart;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services.Interfaces.Cart
{
    public interface IPaymentService
    {
        Task<ServiceResponse> Pay(decimal totalAmount, IEnumerable<Product> cartProducts, IEnumerable<ProcessCart> carts);
    }
}
