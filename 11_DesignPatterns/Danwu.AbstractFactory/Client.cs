using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.AbstractFactory
{
    public class Client
    {
        AbstractFactory bj_factory = new BeiJingFactory();
        AbstractFactory sh_factory = new ShangHaiFactory();

        public Client() { 
            
        }

        public void Method() {
            var bj_drink = bj_factory.CreateDrink();
            var bj_fruit = bj_factory.CreateFruit();
            var bj_meat = bj_factory.CreateMeat();
        }
    }
}
