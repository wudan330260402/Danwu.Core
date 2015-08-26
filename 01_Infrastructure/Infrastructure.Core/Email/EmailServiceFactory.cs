﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Email
{
    public class EmailServiceFactory
    {
        private static IEmailService _emailService;

        public static void InitializeEmailServiceFactory(IEmailService emailService) {
            _emailService = emailService;
        }

        public static IEmailService GetEmailServiceInstance() {
            return _emailService;
        }
    }
}
