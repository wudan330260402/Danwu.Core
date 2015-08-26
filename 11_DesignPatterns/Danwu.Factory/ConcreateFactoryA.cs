using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.Factory
{
    public class ConcreateFactoryA : AbstractFactory
    {
        public override Product CreateProduct()
        {
            return new ConcreateProductA();
        }
    }
}
