using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Mapper
{
    public class DataMapper
    {
        static MapperBase mapper = null;

        static DataMapper() {
            mapper = new AutoDataMapper();
            mapper.InitMapperConfig();
        }

        public static TDest Map<TSource, TDest>(TSource source)
        {
            return mapper.Map<TSource, TDest>(source);
        }
    }
}
