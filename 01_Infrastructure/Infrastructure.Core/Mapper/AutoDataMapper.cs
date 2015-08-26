using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace Infrastructure.Core.Mapper
{
    public class AutoDataMapper : MapperBase
    {

        public override TDest Map<TSource, TDest>(TSource source)
        {
            throw new NotImplementedException();
        }

        public override void InitMapperConfig()
        {
            throw new NotImplementedException();
        }
    }
}
