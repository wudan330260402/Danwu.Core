using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.CQRS.Events
{
    public class EventBus : IEventBus
    {

        public void Publish<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

    }
}
