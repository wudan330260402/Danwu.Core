using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Exceptions
{
    public class ValueObjectInvalidException : Exception
    {

        public ValueObjectInvalidException(String message)
            : base(message)
        { }

    }
}
