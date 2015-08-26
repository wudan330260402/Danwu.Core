
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;

namespace Infrastructure.Core.Test.aop.EntLibProxy
{
    public class UserHandler : ICallHandler
    {

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.PassWord.Length < 0) {
                return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
            }
            Console.WriteLine("参数检测无误");
            return getNext()(input, getNext);
        }

        public int Order
        {
            get;
            set;
        }

    }

    public class UserHandlerAttribute : HandlerAttribute {

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new UserHandler() { Order = this.Order };
            return handler;
        }

    }

    [UserHandler(Order = 1)]
    public interface IUserProcessor
    {
        void RegUser(User user);
    }

    public class UserProcessor : MarshalByRefObject, IUserProcessor {
        private static UserProcessor proxyInstance;
        private static Object lockObj = new Object();

        public static UserProcessor ProxyInstance
        {
            get
            {
                if (proxyInstance == null)
                {
                    lock (lockObj)
                    {
                        if (proxyInstance == null)
                        {
                            proxyInstance = PolicyInjection.Create<UserProcessor>();
                        }
                    }
                }
                return proxyInstance;
            }
        }

        public void RegUser(User user)
        {
            Console.WriteLine("用户已注册。");
        }

    }
}
