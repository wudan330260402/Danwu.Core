using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IDrink CreateDrink();

        public abstract IFruit CreateFruit();

        public abstract IMeat CreateMeat();
    }

    public class BeiJingFactory : AbstractFactory {

        public override IDrink CreateDrink()
        {
            return new Juice();
        }

        public override IFruit CreateFruit()
        {
            return new Apple();
        }

        public override IMeat CreateMeat()
        {
            return new Beef();
        }
    }

    public class ShangHaiFactory : AbstractFactory {

        public override IDrink CreateDrink()
        {
            return new Milk();
        }

        public override IFruit CreateFruit()
        {
            return new Orange();
        }

        public override IMeat CreateMeat()
        {
            return new Pig();
        }
    }
}
