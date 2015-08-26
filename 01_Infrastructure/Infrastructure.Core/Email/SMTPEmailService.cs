using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Email
{
    public class SMTPEmailService : IEmailService
    {

        public void SendMail(string from, string to, string subject, string body)
        {
            throw new NotImplementedException();
        }

    }
}