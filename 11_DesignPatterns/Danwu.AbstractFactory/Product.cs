using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.AbstractFactory
{
    #region IDrink

    /// <summary>
    /// 饮料接口
    /// </summary>
    public abstract class IDrink
    {
        
    }
    /// <summary>
    /// 水果汁
    /// </summary>
    public class Juice : IDrink
    {

    }
    /// <summary>
    /// 牛奶
    /// </summary>
    public class Milk : IDrink
    {

    }

    #endregion

    #region IFruit

    /// <summary>
    /// 水果接口
    /// </summary>
    public abstract class IFruit
    {
        
    }

    /// <summary>
    /// 苹果
    /// </summary>
    public class Apple : IFruit
    {

    }
    /// <summary>
    /// 橘子
    /// </summary>
    public class Orange : IFruit
    {

    }

    #endregion

    #region IMeat

    /// <summary>
    /// 肉类接口
    /// </summary>
    public abstract class IMeat
    {

    }

    /// <summary>
    /// 牛肉
    /// </summary>
    public class Beef : IMeat
    {

    }
    /// <summary>
    /// 猪肉
    /// </summary>
    public class Pig : IMeat
    {

    }

    #endregion

}
