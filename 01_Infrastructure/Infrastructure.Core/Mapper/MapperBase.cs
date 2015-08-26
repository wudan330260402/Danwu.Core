using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Mapper
{
    public abstract class MapperBase
    {
        public abstract void InitMapperConfig();

        public abstract TDest Map<TSource, TDest>(TSource source);
    }

}
