using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Events
{
    public delegate void CommonEventHandler<S,E>(S sender,E eventArgs);
    public delegate void BatchEventHandler<S,E>(IEnumerable<S> senders,E eventArgs);
}
