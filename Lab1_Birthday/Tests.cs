using System;
using NUnit.Framework;

namespace Lab1_Birthday
{
    [TestFixture]
    public class Tests
    {
        private Info _info;

        [SetUp]
        public void Init()
        {
            _info = new Info();
        }

        [Test]
        public void Is_My_BirthDay()
        {
            _info.BirthDay = DateTime.Now.Date;
            var actual = _info.IsBirthDay();
            Assert.IsTrue(actual);
        }

        [Test]
        public void Is_Not_My_BirthDay()
        {
            _info.BirthDay = new DateTime().Date;
            var actual = _info.IsBirthDay();
            Assert.IsFalse(actual);
        }
    }
}