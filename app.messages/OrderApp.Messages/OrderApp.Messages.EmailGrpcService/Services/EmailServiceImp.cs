using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace OrderApp.Messages.EmailGrpcService
{
    public class EmailServiceImp : EmailService.EmailServiceBase
    {
        private readonly ILogger<EmailServiceImp> _logger;
        public EmailServiceImp(ILogger<EmailServiceImp> logger)
        {
            _logger = logger;
        }

        public override Task<SendEmailReply> SendEmail(SendEmailRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Sent email to: {address}", request.Address);
            
            return Task.FromResult(new SendEmailReply());
        }
    }
}
