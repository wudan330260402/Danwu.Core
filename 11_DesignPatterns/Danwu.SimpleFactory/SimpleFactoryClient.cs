using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.SimpleFactory
{
    public class SimpleFactoryClient
    {
        SimpleFactory factory = new SimpleFactory();
        Product product = null;

        public SimpleFactoryClient()
        {
            product = factory.CreateProduct(ProductType.ProductA);
        }

        public SimpleFactory SimpleFactory
        {
            get
            {
                return factory;
            }
        }

        public Product Product
        {
            get
            {
                return product;
            }
        }

        public void Method1() {
            product.Method1();
        }
        public void Method2() {
            product.Method2();
        }
    }
}
