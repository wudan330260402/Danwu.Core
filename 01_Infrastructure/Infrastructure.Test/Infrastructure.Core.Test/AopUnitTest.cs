using System;
using System.Linq;
using System.Linq.Expressions; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infrastructure.Core.Caching;
using Infrastructure.Core.Log;
using Infrastructure.Core.Extension;
using System.Collections.Generic;

using Infrastructure.Core.Test.aop;
using StatisProxy = Infrastructure.Core.Test.aop.StatisProxy;
using DynamicProxy = Infrastructure.Core.Test.aop.DynamicProxy;
using CastleDynamicProxy = Infrastructure.Core.Test.aop.CastleDynamicProxy;
using EntLibProxy = Infrastructure.Core.Test.aop.EntLibProxy;

namespace Infrastructure.Core.Test
{
    [TestClass]
    public class AopUnitTest
    {
        [TestMethod]
        public void StatisAopTest()
        {
            User user = new User() { Name = "wudan", PassWord = "123456" };
            IUserProcessor userProcessor = new StatisProxy.UserProcessorDecorator(new StatisProxy.UserProcessor());
            userProcessor.RegUser(user);
        }

        [TestMethod]
        public void DynamicProxyTest() {
            User user = new User() { Name = "wudan", PassWord = "123456" };
            DynamicProxy.UserProcessor userProcessor = DynamicProxy.TransparentProxy.CreateInstance<DynamicProxy.UserProcessor>();
            userProcessor.RegUser(user);
        }

        [TestMethod]
        public void CastleDynamicProxyTest() {
            User user = new User() { Name = "wudan", PassWord = "123456" };
            CastleDynamicProxy.UserProcessor.ProxyInstance.RegUser(user);
        }

        [TestMethod]
        public void EntLibProxyTest() {
            User user = new User() { Name = "wudan", PassWord = "123456" };
            EntLibProxy.UserProcessor.ProxyInstance.RegUser(user);
        }
    }

}