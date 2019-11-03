using MassTransit;
using Microsoft.Extensions.Logging;
using OrderApp.Api.MessageContract;
using System.Threading.Tasks;

namespace OrderApp.Api.Consumers
{
    public class SendEmailConsumer : IConsumer<SendEmailRequest>
    {
        private readonly ILogger<SendEmailConsumer> _logger;

        public SendEmailConsumer(ILogger<SendEmailConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<SendEmailRequest> context)
        {
            _logger.LogInformation($"Received order data ==>: {context.Message.Address}");
            return Task.CompletedTask;
        }
    }
}
