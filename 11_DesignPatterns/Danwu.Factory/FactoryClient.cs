using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.Factory
{
    public class FactoryClient
    {
        AbstractFactory factory = new ConcreateFactoryA();

        public void Method()
        {
            var product = factory.CreateProduct();
            product.Method();
        }
    }
}
