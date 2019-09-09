using Castle.DynamicProxy;
using NSubstitute;
using NUnit.Framework;

namespace Lab2_Otp
{
    [TestFixture]
    public class Lab1Tests
    {
        private FakeProfileDao _fakeProfileDao;
        private FakeRsaTokenDao _fakeRsaTokenDao;

        [Test]
        public void IsValidTest()
        {
            _fakeProfileDao = new FakeProfileDao()
            {
                Password = "91"
            };
            _fakeRsaTokenDao = new FakeRsaTokenDao()
            {
                RandomKey = "000000"
            };
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao);

            var actual = target.IsValid("joey", "91000000");
            Assert.IsTrue(actual);
        }
        [Test]
        public void NSubIsValidTest()
        {
            var _fakeRsaTokenDao = Substitute.For<IRsaTokenDao>();
            _fakeRsaTokenDao.GetRandom(Arg.Any<string>()).Returns("000000");

            var _fakeProfileDao = Substitute.For<IProfileDao>();
            _fakeProfileDao.GetPassword(Arg.Any<string>()).Returns("91");
            

            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao);

            var actual = target.IsValid("joey", "91000000");
            Assert.IsTrue(actual);
        }
        [Test]
        public void NSubIsInvalidTest()
        {
            var _fakeRsaTokenDao = Substitute.For<IRsaTokenDao>();
            _fakeRsaTokenDao.GetRandom(Arg.Any<string>()).Returns("111111");

            var _fakeProfileDao = Substitute.For<IProfileDao>();
            _fakeProfileDao.GetPassword(Arg.Any<string>()).Returns("91");
            

            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao);

            var actual = target.IsValid("joey", "91000000");
            Assert.IsFalse(actual);
        }
        [Test]
        public void IsInvalidTest()
        {
            _fakeProfileDao = new FakeProfileDao()
            {
                Password = "92"
            };
            _fakeRsaTokenDao = new FakeRsaTokenDao()
            {
                RandomKey = "111111"
            };
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao);

            var actual = target.IsValid("joey", "91000000");
            Assert.IsFalse(actual);
        }
    }

    public class FakeRsaTokenDao : IRsaTokenDao
    {
        public string RandomKey;

        public string GetRandom(string account)
        {
            return RandomKey;
        }
    }

    public class FakeProfileDao : IProfileDao
    {
        public string Password;

        public string GetPassword(string account)
        {
            return Password;
        }
    }
}