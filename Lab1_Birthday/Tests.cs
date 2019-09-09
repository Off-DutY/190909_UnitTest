using System;
using NUnit.Framework;

namespace Lab1_Birthday
{
    [TestFixture]
    public class Tests
    {
        private fakeInfo _info;

        [SetUp]
        public void Init()
        {
            _info = new fakeInfo();
        }

        [Test]
        public void Is_My_BirthDay()
        {
            _info.today = DateTime.Now;
            
            var actual = _info.IsBirthDay();
            Assert.IsTrue(actual);
        }

        [Test]
        public void Is_Not_My_BirthDay()
        {
            _info.today = new DateTime();
            
            var actual = _info.IsBirthDay();
            Assert.IsFalse(actual);
        }
    }

    public class fakeInfo : Info
    {
        public DateTime today { get; set; }

        protected override DateTime GetToday()
        {
            return today;
        }
    }
}