using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;

namespace Infrastructure.Core.Test.aop.DynamicProxy
{
    /// <summary>
    /// 透明代理
    /// </summary>
    public class TransparentProxy
    {
        public static T CreateInstance<T>() {
            T instance = Activator.CreateInstance<T>();
            DanwuRealProxy<T> realProxy = new DanwuRealProxy<T>(instance);
            T transparentProxy = (T)realProxy.GetTransparentProxy();
            return transparentProxy;
        }
    }

    public class DanwuRealProxy<T> : RealProxy
    {
        private T _target;
        public DanwuRealProxy(T target)
            : base(typeof(T))
        {
            this._target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            PreProceede(msg);
            IMethodCallMessage callMessage = (IMethodCallMessage)msg;
            Object returnValue = callMessage.MethodBase.Invoke(this._target, callMessage.Args);
            PostProceede(msg);

            return new ReturnMessage(returnValue, new Object[0], 0, null, callMessage);
        }

        public void PreProceede(IMessage msg)
        {
            Console.WriteLine("方法执行前");
        }
        public void PostProceede(IMessage msg)
        {
            Console.WriteLine("方法执行后");
        }
    }

    /// <summary>
    /// 通过动态代理方式实现aop
    /// </summary>
    public class UserProcessor : MarshalByRefObject, IUserProcessor {

        public void RegUser(User user)
        {
            Console.WriteLine("用户已注册。");
        }

    }
}
