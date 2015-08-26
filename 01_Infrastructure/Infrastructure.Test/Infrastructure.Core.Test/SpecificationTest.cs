using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infrastructure.Core.Extension;
using Infrastructure.Core.Specifications;
using System.Linq.Expressions;

namespace Infrastructure.Core.Test
{
    /// <summary>
    /// SpecificationTest 的摘要说明
    /// </summary>
    [TestClass]
    public class SpecificationTest
    {
        public SpecificationTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: 在此处添加测试逻辑
            //

            var array = new Int32[] { -10, -7, -6, 0, 1, 2, 4, 5, 6, 7, 8 };
            var even = new EvenSpecification();
            var positive = new PositiveSpecification();
            var third = new ThirdSpecification();
            var specification = new AndSpecification<Int32>(even, positive).And(third);
            var list = array.Where(item => specification.IsSatisfiedBy(item));
            foreach (var item in list) {
                Console.WriteLine(item);
            }

            System.Threading.Thread.Sleep(100000);
        }
    }

    /// <summary>
    /// 偶数规则
    /// </summary>
    public class EvenSpecification : Specification<Int32>
    {
        public override Expression<Func<int, bool>> GetExpression()
        {
            return item => item % 2 == 0;
        }
    }

    public class PositiveSpecification : Specification<Int32>
    {
        public override Expression<Func<int, bool>> GetExpression()
        {
            return item => item > 0;
        }
    }

    public class ThirdSpecification : Specification<Int32> {

        public override Expression<Func<int, bool>> GetExpression()
        {
            return item => item % 3 == 0;
        }

    }
}
