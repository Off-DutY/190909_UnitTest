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
        public void IsValidTest()
        {
            GiveRsaToken("000000");
            GivePassword("91");

            ShouldBeValid("joey", "91000000");
        }

        [Test]
        public void IsInvalidTest()
        {
            GiveRsaToken("001100");
            GivePassword("92");

            ShouldBeInvalid("joey", "91000000");
        }

        [Test]
        public void InvalidAndLogMessageTest()
        {
            GiveRsaToken("001100");
            GivePassword("92");

            ShouldBeInvalid("joey", "91000000");
            ShouldLog1TimesMessage("joey");
        }

        private void ShouldLog1TimesMessage(object accountName)
        {
            _logService.Received(1).Log($"account={accountName}");
        }

        private void ShouldBeInvalid(string account, string passcode)
        {
            var target = new Lab1AuthenticationService(_fakeProfileDao, _fakeRsaTokenDao, _logService);

            var actual = target.IsValid(account, passcode);
            Assert.IsFalse(actual);
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