using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderApp.Api.Services;
using OrderApp.Messages.EmailGrpcService;

namespace OrderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IBus _bus;
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(IOrderServices orderServices, IBus bus, ILogger<ValuesController> logger)
        {
            _orderServices = orderServices;
            _bus = bus;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            string currentTime = DateTime.Now.ToString();
            _logger.LogInformation($"Sent order data: {currentTime}");
            await _bus.Publish<MessageContract.SendEmailRequest>(
            new
            {
                Address = "abc@xyz.com"
            });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Channel channel = new Channel("127.0.0.1:5001", ChannelCredentials.Insecure);

            var client = new EmailService.EmailServiceClient(channel);

            var reply = client.SendEmail(new Messages.EmailGrpcService.SendEmailRequest { Address = "thunghiem@hhh.com" });

            channel.ShutdownAsync().Wait();
            return "xong";
        }

        // GET api/values/5
        [HttpGet("entity/{id}")]
        public ActionResult<string> GetEntity(int id)
        {

            return "avx";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
