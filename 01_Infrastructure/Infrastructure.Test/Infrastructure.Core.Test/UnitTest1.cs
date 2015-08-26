using System;
using System.Linq;
using System.Linq.Expressions; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infrastructure.Core.Caching;
using Infrastructure.Core.Log;
using Infrastructure.Core.Extension;
using System.Collections.Generic;

namespace Infrastructure.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CacheTest()
        {
            CacheHelper.Add("UserId", "10001");
            CacheHelper.Add("UserName", "wudan");

            String userId = CacheHelper.Get("UserId") == null ? String.Empty : CacheHelper.Get("UserId").ToString();

            CacheHelper.Remove("UserId");

            userId = String.Empty;
            userId = CacheHelper.Get("UserId") == null ? String.Empty : CacheHelper.Get("UserId").ToString();
        }

        [TestMethod]
        public void LogTest()
        {
            LogHelper.WriteInfo("info测试", "info测试测试测试");
            LogHelper.WriteDebug("debug测试", "debug测试测试测试");
            LogHelper.WriteError("error测试", "error测试测试测试");
            LogHelper.WriteException("exception测试", new Exception("exception测试测试测试"));
        }

        [TestMethod]
        public void LambdaTest() {
            Expression<Func<Int32, bool>> express = (a) => a == 3 && a != 4;
            var value = express.GetValue();
            var count = express.GetCriteriaCount();

            Expression<Func<ExpressionType, bool>> exp = (e) => express.NodeType == ExpressionType.Add;
            var val = exp.GetValue();

        }

        [TestMethod]
        public void NullableTest() {
            Int32? a = null;
            Int32? b = 4;

            DateTime? t1 = null;
            DateTime? t2 = DateTime.Now;

            var result = a.SafeValue();
            result = b.SafeValue();
            var result2 = t1.SafeValue();
            result2 = t2.SafeValue();

            String aa = String.Empty;
            Int32 bb = 3;

            if (a.IsNullOrEmpty()) Console.WriteLine("a is null");
            if (b.IsNullOrEmpty()) Console.WriteLine("b is null");

            if (t1.IsNullOrEmpty()) Console.WriteLine("t1 is null");
            if (t2.IsNullOrEmpty()) Console.WriteLine("t2 is null");

            if (aa.IsNullOrEmpty()) Console.WriteLine("aa is null");
            if (bb.IsNullOrEmpty()) Console.WriteLine("bb is null");


            A acls = new A();
            B bcls = acls as B;
        }

        [TestMethod]
        public void ExpressionTest() {
            Expression<Func<Int32, Boolean>> exp1 = (a) => a % 2 == 0;
            Expression<Func<Int32, Boolean>> exp2 = (b) => b % 3 == 0;

            var exp3 = exp1.Compose(exp2, Expression.And);

            var array = new Int32[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            array.Where(exp3.Compile()).ForEach(item =>
            {
                Console.WriteLine(item);
            });


            System.Threading.Thread.Sleep(1000);
        }

        [TestMethod]
        public void SpecificationTest() { 
            
        }
    }

    public class A { 
        
    }

    public class B:A { 
        
    }

}