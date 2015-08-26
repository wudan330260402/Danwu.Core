using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.SimpleFactory
{
    public class SimpleFactory
    {    
        public Product CreateProduct(ProductType productType) {
            Product product = default(Product);
            switch (productType) { 
                case ProductType.ProductA:
                    product = new ConcreateProductA();
                    break;
                case ProductType.ProductB:
                    product = new ConcreateProductB();
                    break;
            }
            return product;
        }
    }
}
