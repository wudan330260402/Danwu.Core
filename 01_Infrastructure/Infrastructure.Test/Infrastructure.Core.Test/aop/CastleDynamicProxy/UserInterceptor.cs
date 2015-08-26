using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Castle.DynamicProxy;

namespace Infrastructure.Core.Test.aop.CastleDynamicProxy
{
    /// <summary>
    /// user拦截器
    /// </summary>
    public class UserInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            PreProcessor(invocation);
            invocation.Proceed();
            PostProcessor(invocation);
        }

        public void PreProcessor(IInvocation invocation) {
            Console.WriteLine("方法执行前");
        }

        public void PostProcessor(IInvocation invocation)
        {
            Console.WriteLine("方法执行后");
        }
    }

    public class UserProcessor : IUserProcessor
    {
        private static UserProcessor proxyInstance;
        private static Object lockObj = new Object();

        public static UserProcessor ProxyInstance {
            get {
                if (proxyInstance == null) {
                    lock (lockObj) {
                        if (proxyInstance == null) {
                            ProxyGenerator generator = new ProxyGenerator();
                            UserInterceptor interceptor = new UserInterceptor();
                            proxyInstance = generator.CreateClassProxy<UserProcessor>(interceptor);
                        }
                    }
                }
                return proxyInstance;
            }
        }
        public virtual void RegUser(User user)
        {
            Console.WriteLine("用户已注册。Name:{0},PassWord:{1}", user.Name, user.PassWord);
        }
    }
}
