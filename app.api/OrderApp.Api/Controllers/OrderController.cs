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
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IBus _bus;
        private readonly ILogger<ValuesController> _logger;
        public OrderController(IOrderServices orderServices, IBus bus, ILogger<ValuesController> logger)
        {
            _orderServices = orderServices;
            _bus = bus;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<OrderViewModel>> Get()
        {
            var result = _orderServices.GetAllOrder();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<OrderViewModel> Get(int id)
        {
            var result = _orderServices.GetOrderById(id);
            return Ok(result);
        }

        [HttpGet("approve/{id}")]
        public ActionResult<OrderViewModel> Approve(int id)
        {
            var result = _orderServices.Approve(id);
            return Ok(result);
        }

        [HttpGet("reject/{id}")]
        public ActionResult<OrderViewModel> Reject(int id)
        {
            var result = _orderServices.Reject(id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Put([FromBody] OrderViewModel model)
        {
            var result = _orderServices.Add(model);
            return Ok(result);
        }
    }
}
