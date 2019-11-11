using System.Collections.Generic;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderApp.Api.Services;
using OrderApp.Api.ViewModel;

namespace OrderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IBus _bus;
        private readonly ILogger<ValuesController> _logger;
        public ProductController(IProductServices productServices, IBus bus, ILogger<ValuesController> logger)
        {
            _productServices = productServices;
            _bus = bus;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> Get()
        {
            var result = _productServices.GetProducts();
            return Ok(result);
        }
    }
}
