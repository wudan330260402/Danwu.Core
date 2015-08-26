using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Client
{
    class Program
    {
        static void Main(String[] args) {
            BusConfiguration busConfig = new BusConfiguration();
            busConfig.EndpointName("NServiceBusDemo.Client");
            busConfig.UseSerialization<JsonSerializer>();
            busConfig.EnableInstallers();
            busConfig.UsePersistence<InMemoryPersistence>();

            using (IBus bus = Bus.Create(busConfig).Start())
            {
                CreateUser(bus);
            }
        }

        static void CreateUser(IBus bus) {
            Console.WriteLine("Press enter to send a message");
            Console.WriteLine("Press any key to exit");

            while (true) {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key != ConsoleKey.Enter) {
                    return;
                }

                var cmd = new CreateUserCmd()
                {
                    ID = Guid.NewGuid(),
                    Name = "test",
                    EmailAddress = "1@1.com"
                };

                bus.Send("NServiceBusDemo.Service", cmd);

            }
        }
    }    
}
