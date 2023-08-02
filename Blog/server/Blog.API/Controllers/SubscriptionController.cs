using Blog.Common;
using Blog.DTO.SubscriptionDTO;
using Blog.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscription()
        {
            try
            {
                List<SubscriptionResponseDTO> subscriptionsResult = await _subscriptionService.GetAllSubscriptionAsync();

                return Ok(new { data = subscriptionsResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("{id}", Name = "SubscriptionById")]
        public async Task<IActionResult> GetSubscriptionById(Guid id)
        {
            try
            {
                SubscriptionResponseDTO subscriptionResult = await _subscriptionService.GetSubscriptionByIdAsync(id);

                if (subscriptionResult == null) return NotFound();

                return Ok(new { data = subscriptionResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionCreateDTO sub)
        {
            try
            {
                if (sub == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "Subscription"));

                bool exist = await _subscriptionService.AnySubscriptionAsync(sub.Email);
                if (exist) return BadRequest(String.Format(GlobalConstants.OBJECT_EXIST, "Subscription", "Email"));
                SubscriptionResponseDTO createdSub = await _subscriptionService.CreateSubscriptionAsync(sub);

                return CreatedAtRoute("SubscriptionById", new { id = createdSub.Id }, createdSub);

            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSubscription([FromBody] SubscriptionUpdateDTO sub)
        {
            try
            {
                if (sub == null) return BadRequest(String.Format(GlobalConstants.OBJECT_NULL, "Subscription"));

                SubscriptionResponseDTO subEntity = await _subscriptionService.UpdateSubscriptionAsync(sub);
                if (subEntity == null) return NotFound();

                return Ok(new { data = subEntity });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            try
            {
                string sub = await _subscriptionService.DeleteSubscriptionAsync(id);
                if (sub == null) return NotFound();

                return Ok(new { data = sub });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("any")]
        public async Task<IActionResult> AnySubscriptionExist([FromQuery] string email)
        {
            try
            {
                var catExist = await _subscriptionService.AnySubscriptionAsync(email);

                return Ok(new { data = catExist });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> SubscriptionCount()
        {
            try
            {
                var subCount = await _subscriptionService.CountAllSubscriptionAsync();

                return Ok(new { data = subCount });
            }
            catch (Exception ex)
            {
                return StatusCode(500, GlobalConstants.SERVER_ERROR + ex);
            }
        }
    }
}
