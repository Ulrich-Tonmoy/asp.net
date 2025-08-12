using AutoMapper;
using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Cart;
using eCommerce.Application.Services.Interfaces.Cart;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Interfaces;
using eCommerce.Domain.Interfaces.Authentication;
using eCommerce.Domain.Interfaces.Cart;

namespace eCommerce.Application.Services.Cart
{
    public class CartService(ICart cartInterface, IMapper mapper, IGeneric<Product> productInterface, IPaymentMethodService paymentMethodService, IPaymentService paymentService, IUserManagement userManagement) : ICartService
    {
        public async Task<ServiceResponse> Checkout(Checkout checkout)
        {
            var (products, totalAmount) = await GetTotalAmount(checkout.Carts);
            var paymentMethods = await paymentMethodService.GetPaymentMethods();

            if (checkout.PaymentMethodId == paymentMethods.FirstOrDefault()!.Id)
                return await paymentService.Pay(totalAmount, products, checkout.Carts);

            return new ServiceResponse(false, "Invalid payment method");
        }

        public async Task<IEnumerable<GetArchives>> GetArchives()
        {
            var history = await cartInterface.GetAllCheckoutHistory();
            if (history == null) return [];

            var groupByCustomerId = history.GroupBy(x => x.UserId).ToList();
            var products = await productInterface.GetAllAsync();
            var archives = new List<GetArchives>();
            foreach (var customerId in groupByCustomerId)
            {
                var customerDetails = await userManagement.GetUserById(customerId.Key!);
                foreach (var item in customerId)
                {
                    var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                    if (product is not null)
                        archives.Add(new GetArchives
                        {
                            CustomerEmail = customerDetails.Email,
                            CustomerName = customerDetails.UserName,
                            ProductName = product!.Name,
                            AmountPayed = item.Quantity * product.Price,
                            QuantityOrdered = item.Quantity,
                            DatePurchased = item.CreatedDate,
                        });
                }
            }
            return archives;
        }

        public async Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateArchives> achives)
        {
            var mappeedData = mapper.Map<IEnumerable<Archive>>(achives);
            var results = await cartInterface.SaveCheckoutHistory(mappeedData);
            return results > 0 ? new ServiceResponse(true, "Checkout archieved") : new ServiceResponse(false, "Error occured while saving ");
        }

        private async Task<(IEnumerable<Product>, decimal)> GetTotalAmount(IEnumerable<ProcessCart> carts)
        {
            if (!carts.Any()) return ([], 0);

            var products = await productInterface.GetAllAsync();
            if (!products.Any()) return ([], 0);

            var cartProducts = carts.Select(item => products.FirstOrDefault(p => p.Id == item.ProductId))
                .Where(product => product != null)
                .ToList();

            var totalAmount = carts.Where(item => cartProducts.Any(p => p.Id == item.ProductId))
                .Sum(item => item.Quantity * cartProducts.First(p => p.Id == item.ProductId)!.Price);
            return (cartProducts!, totalAmount);
        }
    }
}
