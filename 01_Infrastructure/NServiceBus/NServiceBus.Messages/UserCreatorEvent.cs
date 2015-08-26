using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Messages
{
    public class UserCreatorEvent : IEvent
    {
        public Guid ID { get; set; }
    }
}
