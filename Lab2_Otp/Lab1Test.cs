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
        private ILogService _logService;

        [SetUp]
        public void Init()
        {
            _fakeRsaTokenDao = Substitute.For<IRsaTokenDao>();
            _fakeProfileDao = Substitute.For<IProfileDao>();
            _logService = Substitute.For<ILogService>();
        }

        [Test]
        public void IsValid()
        {
            GiveRsaToken("000000");
            GivePassword("91");

            ShouldBeValid("joey", "91000000");
        }

        [Test]
        public void IsInvalid()
        {
            GiveRsaToken("001100");
            GivePassword("92");

            ShouldBeInvalid("joey", "91000000");
        }

        [Test]
        public void LogMessageWhenInvalid()
        {
            WhenInvalidCase("joey");
            ShouldLogMessage1Times("joey");
        }

        private void WhenInvalidCase(string account)
        {
            GiveRsaToken("123");
            GivePassword("456");

            InvalidCase(account, account);
        }

        private void ShouldLogMessage1Times(string accountName)
        {
            _logService.Received(1).Log(Arg.Is<string>(s => s.Contains(accountName)));
        }

        private void ShouldBeInvalid(string account, string passcode)
        {
            var actual = InvalidCase(account, passcode);
            Assert.IsFalse(actual);
        }

        private bool InvalidCase(string account, string passcode)
        {
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao, _logService);

            var actual = target.IsValid(account, passcode);
            return actual;
        }

        private void ShouldBeValid(string account, string passcode)
        {
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao, _logService);
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