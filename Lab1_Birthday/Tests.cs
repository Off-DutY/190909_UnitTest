using System;
using NUnit.Framework;

namespace Lab1_Birthday
{
    [TestFixture]
    public class Tests
    {
        private Info _info;
        private FakeDateTimeHelper _fakeDateTimeHelper;

        [SetUp]
        public void Init()
        {
            _fakeDateTimeHelper = new FakeDateTimeHelper();
            _info = new Info(_fakeDateTimeHelper);
        }

        [Test]
        public void Is_My_BirthDay()
        {
            _fakeDateTimeHelper.today = DateTime.Now;

            var actual = _info.IsBirthDay();
            Assert.IsTrue(actual);
        }

        
        [Test]
        public void Is_Not_My_BirthDay()
        {
            _fakeDateTimeHelper.today = new DateTime();
            
            var actual = _info.IsBirthDay();
            Assert.IsFalse(actual);
        }
    }

    public class FakeDateTimeHelper : DateTimeHelper
    {
        public DateTime today { get; set; }

        public override DateTime GetToday()
        {
            return today;
        }
    }
}