using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.Factory
{
    public abstract class Product
    {
        public abstract void Method();
    }

    public class ConcreateProductA : Product
    {
        public override void Method()
        {
            Console.WriteLine("this is ProductA's method1");
        }
    }

    public class ConcreateProductB : Product
    {

        public override void Method()
        {
            Console.WriteLine("this is ProductB's method1");
        }

    }
}
