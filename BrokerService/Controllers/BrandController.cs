using Microsoft.AspNetCore.Mvc;
using sep3.brokers.broker;

namespace sep3.brokers.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandBroker _brandBroker;

        public BrandController(IBrandBroker brandBroker)
        {
            _brandBroker = brandBroker;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var result = await _brandBroker.GetBrandAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve brand.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _brandBroker.GetAllBrandsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
    }
}