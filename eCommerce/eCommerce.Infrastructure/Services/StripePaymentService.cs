using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Cart;
using eCommerce.Application.Services.Interfaces.Cart;
using eCommerce.Domain.Entities;
using Stripe.Checkout;

namespace eCommerce.Infrastructure.Services
{
    public class StripePaymentService : IPaymentService
    {
        public async Task<ServiceResponse> Pay(decimal totalAmount, IEnumerable<Product> cartProducts, IEnumerable<ProcessCart> carts)
        {
            try
            {
                var lineItems = new List<SessionLineItemOptions>();
                foreach (var product in cartProducts)
                {
                    var pQuantity = carts.FirstOrDefault(_ => _.ProductId == product.Id);
                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = product.Name,
                                Description = product.Description,
                            },
                            UnitAmount = (long)(product.Price * 100),
                        },
                        Quantity = pQuantity!.Quantity
                    });
                }

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = ["card"],
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = "http://localhost:5297/payment-success",
                    CancelUrl = "http://localhost:5297/payment-cancel",
                };

                var service = new SessionService();
                Session session = await service.CreateAsync(options);
                return new ServiceResponse(true, session.Url);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, ex.Message);
            }
        }
    }
}
