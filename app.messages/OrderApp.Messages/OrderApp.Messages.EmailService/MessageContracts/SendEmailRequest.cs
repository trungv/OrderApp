using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Messages.EmailService.MessageContracts
{
    public class SendEmailRequest
    {
        public string Address { get; set; }
    }
}
