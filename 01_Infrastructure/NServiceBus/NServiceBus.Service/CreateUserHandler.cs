using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NServiceBus;
using NServiceBus.Logging;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Service
{
    public class CreateUserHandler : IHandleMessages<CreateUserCmd>
    {
        IBus bus;
        public CreateUserHandler(IBus bus) {
            this.bus = bus;
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(CreateUserHandler));

        public void Handle(CreateUserCmd message)
        {
            log.InfoFormat("Create user '{0}' with email '{1}'", message.Name, message.EmailAddress);
            var @event = new UserCreatorEvent()
            {
                ID = message.ID
            };

            bus.Publish(@event);
        }
    }
}
