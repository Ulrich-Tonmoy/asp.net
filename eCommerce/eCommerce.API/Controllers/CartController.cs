using eCommerce.Application.DTOs.Cart;
using eCommerce.Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpPost("checkout")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> Checkout(Checkout checkout)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await cartService.Checkout(checkout);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("save")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> SaveCheckout(IEnumerable<CreateArchives> archives)
        {
            var result = await cartService.SaveCheckoutHistory(archives);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("archive")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllCheckoutHistory()
        {
            var result = await cartService.GetArchives();

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
