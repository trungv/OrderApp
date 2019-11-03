using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MassTransit;

namespace OrderApp.Messages.Services
{
    public class SendOrderConsumer : IConsumer<SendEmailRequest>
    {
        private readonly ILogger<SendOrderConsumer> _logger;

        public SendOrderConsumer(ILogger<SendOrderConsumer> logger)
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
