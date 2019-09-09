using Castle.DynamicProxy;
using NSubstitute;
using NUnit.Framework;

namespace Lab2_Otp
{
    [TestFixture]
    public class Lab1Tests
    {
        private IProfileDao _fakeProfileDao;
        private IRsaTokenDao _fakeRsaTokenDao;

        [SetUp]
        public void Init()
        {
            _fakeRsaTokenDao = Substitute.For<IRsaTokenDao>();
            _fakeProfileDao = Substitute.For<IProfileDao>();
        }

        [Test]
        public void NSubIsValidTest()
        {
            GiveRsaToken("000000");
            GivePassword("91");

            ShouldBeValid("joey", "91000000");
        }

        [Test]
        public void NSubIsInvalidTest()
        {
            GiveRsaToken("001100");
            GivePassword("92");

            ShouldBeInValid("joey", "91000000");
        }

        private void ShouldBeInValid(string account, string passcode)
        {
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao);

            var actual = target.IsValid(account, passcode);
            Assert.IsFalse(actual);
        }

        private void ShouldBeValid(string account, string passcode)
        {
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao);
            var actual = target.IsValid(account, passcode);
            Assert.IsTrue(actual);
        }

        private void GivePassword(string assignPassword)
        {
            _fakeProfileDao.GetPassword(Arg.Any<string>()).Returns(assignPassword);
        }

        private void GiveRsaToken(string assignToken)
        {
            _fakeRsaTokenDao.GetRandom(Arg.Any<string>()).Returns(assignToken);
        }
    }
}