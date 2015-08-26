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
            busConfig.EndpointName("NServiceBusDemo.Server");
            busConfig.UseSerialization<JsonSerializer>();
            busConfig.EnableInstallers();
            busConfig.UsePersistence<InMemoryPersistence>();

            using (IBus bus = Bus.Create(busConfig).Start())
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }    
}
