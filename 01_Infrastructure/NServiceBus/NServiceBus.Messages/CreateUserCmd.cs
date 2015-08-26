using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Messages
{
    public class CreateUserCmd : ICommand
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public String EmailAddress { get; set; }
    }
}
