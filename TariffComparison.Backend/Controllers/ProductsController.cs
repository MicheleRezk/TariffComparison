using Microsoft.AspNetCore.Mvc;
using TariffComparison.Backend.Common;
using TariffComparison.Backend.Dtos;

namespace TariffComparison.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // GET api/products/4500
        [HttpGet("{consumptionPerYear}")]
        public ActionResult<IEnumerable<ProductDto>> GetByConsumptionPerYear(decimal consumptionPerYear)
        {
            if (consumptionPerYear<0)
            {
                return BadRequest($"Consumption {consumptionPerYear} kWh must be greater than or equal 0");
            }
            var tariffs = _productServices.GetAllTariffs(consumptionPerYear);
            return Ok(tariffs);
        }
       
    }
}
