
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Exceptions;

namespace Infrastructure.Core.Repository
{
    public class RepositoryException : RootException
    {
        public RepositoryException()
            : base()
        { }

        public RepositoryException(String message)
            : base(message)
        { }

        public RepositoryException(String message, Exception exception)
            : base(message, exception)
        { }
    }
}
