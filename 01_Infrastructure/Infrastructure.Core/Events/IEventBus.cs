using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Events
{
    public interface IEventBus<S,T>
    {
        event CommonEventHandler<S, T> Before;        
        event CommonEventHandler<S, T> After;
        event BatchEventHandler<S, T> BatchBefore;
        event BatchEventHandler<S, T> BatchAfter;

        void OnBefore(S sender, T eventArgs);        
        void OnAfter(S sender, T eventArgs);
        void OnBatchBefore(IEnumerable<S> senders, T eventArgs);
        void OnBatchAfter(IEnumerable<S> senders, T eventArgs);
    }
}
