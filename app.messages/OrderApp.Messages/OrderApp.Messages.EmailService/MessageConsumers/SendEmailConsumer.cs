using MassTransit;
using Microsoft.Extensions.Logging;
using OrderApp.Messages.EmailService.MessageContracts;
using System.Threading.Tasks;

namespace OrderApp.Messages.Services
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
            _logger.LogInformation($"Sent email to: {context.Message.Address}");
            return Task.CompletedTask;
        }
    }
}
