using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Subscriber
{
    public class UserCreatedHandler : IHandleMessages<UserCreatorEvent>
    {

        public void Handle(UserCreatorEvent message)
        {
            Console.WriteLine(@"Handling: UserCreator for User Id: {0}", message.ID);
        }
    }
}
