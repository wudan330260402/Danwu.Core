using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Test.aop.StatisProxy
{
    /// <summary>
    /// 静态植入方式实现aop
    /// </summary>
    public class UserProcessorDecorator : IUserProcessor
    {
        private IUserProcessor userProcessor;
        public UserProcessorDecorator(IUserProcessor userProcessor) {
            this.userProcessor = userProcessor;
        }

        public void RegUser(User user)
        {
            PreProcess(user);
            userProcessor.RegUser(user);
            PostProcess(user);
        }

        public void PreProcess(User user) {
            Console.WriteLine("方法执行前");
        }
        public void PostProcess(User user) {
            Console.WriteLine("方法执行前");
        }
    }

    public class UserProcessor : IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("用户已注册。Name:{0},PassWord:{1}", user.Name, user.PassWord);
        }
    }

}
