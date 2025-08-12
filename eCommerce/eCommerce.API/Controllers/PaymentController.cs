using eCommerce.Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentMethodService paymentMethodService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetPaymentMethods()
        {
            var methods = await paymentMethodService.GetPaymentMethods();
            if (!methods.Any()) return NotFound();

            return Ok(methods);
        }
    }
}
