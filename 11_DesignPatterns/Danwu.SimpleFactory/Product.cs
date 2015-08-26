using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.SimpleFactory
{
    public abstract class Product
    {
        public abstract void Method1();
        public abstract void Method2();
    }

    public class ConcreateProductA : Product {

        public override void Method1()
        {
            Console.WriteLine("this is ProductA's method1");
        }

        public override void Method2()
        {
            Console.WriteLine("this is ProductA's method2");
        }

    }

    public class ConcreateProductB : Product
    {

        public override void Method1()
        {
            Console.WriteLine("this is ProductB's method1");
        }

        public override void Method2()
        {
            Console.WriteLine("this is ProductB's method2");
        }
    }

    public enum ProductType
    {
        ProductA = 0,
        ProductB = 1
    }
}
