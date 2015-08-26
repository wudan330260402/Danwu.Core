
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Danwu.CQRS.Events;

namespace Danwu.CQRS.EventHandlers
{
    public interface IEventHandler<IEvent> where IEvent : Event
    {
        void Handle(IEvent handle);
    }
}
