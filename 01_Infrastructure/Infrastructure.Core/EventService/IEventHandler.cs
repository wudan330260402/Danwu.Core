using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.EventService
{
    public interface IEventHandler<T>
        where T : IEvent
    {
        void Handler(T evt);
    }
}
