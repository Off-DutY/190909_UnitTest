using System;
using NUnit.Framework;

namespace Lab1_Birthday
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Is_My_BirthDay()
        {
            var actual = new BirthDay().IsBirthDay();
            Assert.IsTrue(actual);
        }
        
        [Test]
        public void Is_Not_My_BirthDay()
        {
            var actual = new BirthDay().IsBirthDay();
            Assert.IsFalse(actual);
        }
    }
}