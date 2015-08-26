using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Email
{
    public interface IEmailService
    {
        void SendMail(String from, String to, String subject, String body);
    }
}
