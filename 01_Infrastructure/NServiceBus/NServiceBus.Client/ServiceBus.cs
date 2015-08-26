using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NServiceBus;
using NServiceBus.Installation.Environments;

namespace NServiceBusDemo.Client
{
    //public static class ServiceBus
    //{
    //    public static IBus Bus { get; private set; }

    //    public static void Init() {
    //        if (Bus != null) return;

    //        Bus = Configure.With()
    //            .DefineEndpointName("Test")
    //            .DefaultBuilder()
    //            .UseTransport<Msmq>()
    //            .PurgeOnStartup(true)
    //            .UnicastBus()
    //            .CreateBus()
    //            .Start(() => Configure.Instance
    //                    .ForInstallationOn<Windows>()
    //                    .Install());
    //    }
    //}
}
