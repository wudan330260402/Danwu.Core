using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Danwu.DataStructureAlgorithms;

namespace Danwu.DataStructureAlgorithms.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SeqLinearList<Int32> intList = new SeqLinearList<int>();
            Console.WriteLine(intList.IsEmpty());
            Console.WriteLine(intList.IsFull());
            Console.WriteLine(intList.GetLength());

            intList.Append(10);

            //Console.ReadLine();
        }
    }
}
