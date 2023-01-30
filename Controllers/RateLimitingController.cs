using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using RateLimitingWebApi.Services;

namespace RateLimitingWebApi.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class RateLimitingController : ControllerBase
    {
        private readonly IRateLimitingService _service;

        public RateLimitingController(IRateLimitingService service)
        {
            _service = service;
        }
        [HttpGet]   
        public async Task<IActionResult> GetPolicies()
        {
            try
            {
                return Ok(await _service.GetIpRateLimitPolicies());
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message= ex.Message;   
                return BadRequest(response);
            }
        }
        [HttpPost]
        public async Task AddPolicies(IpRateLimitPolicies ıpRateLimitPolicies)
        {
            try
            {
                await _service.AddIpRateLimitPolices(ıpRateLimitPolicies);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                BadRequest(response);
            }
        }
    }
}
