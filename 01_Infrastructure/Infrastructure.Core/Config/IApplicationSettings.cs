using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Config
{
    public interface IApplicationSettings
    {
        String LoggerName { get; set; }
    }
}
