using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.CQRS.Commands
{
    public class CommandBus : ICommandBus
    {

        public void Send<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }
    }
}
