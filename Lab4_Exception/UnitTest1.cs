using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab4_Exception
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void TestMethod1()
        {
            throw new MyException();
        }
    }

    public class MyException : Exception
    {
    }
}