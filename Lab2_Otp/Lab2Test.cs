// using NSubstitute;
// using NUnit.Framework;
//
// namespace Lab2_Otp
// {
//     [TestFixture]
//     public class Lab2Tests
//     {
//         [Test]
//         public void IsValidTest_只有驗證Authentication合法或非法()
//         {
//             //arrange
//             IProfile profile = Substitute.For<IProfile>();
//             profile.GetPassword("Joey").Returns("91");
//
//             IToken token = Substitute.For<IToken>();
//             token.GetRandom("Joey").Returns("abc");
//
//             ILog log = Substitute.For<ILog>();
//             Lab2AuthenticationService target = new Lab2AuthenticationService(profile, token, log);
//             string account = "Joey";
//             string password = "wrong password";
//             // 正確的 password 應為 "91abc"
//
//             //act
//             var actual = target.IsValid(account, password);
//
//             // assert
//             Assert.IsFalse(actual);
//         }
//
//         [Test]
//         public void IsValidTest_如何驗證當非法登入時有正確紀錄log()
//         {
//             // 試著使用 stub object 的 ReturnsForAnyArgs() 方法
//             //例如：profile.GetPassword("").ReturnsForAnyArgs("91"); // 不管GetPassword()傳入任何參數，都要回傳 "91"
//         
//             // step 1: arrange, 建立 mock object
//             // ILog log = Substitute.For<ILog>();
//
//             // step 2: act
//
//             // step 3: assert, mock object 是否有正確互動
//             //log.Received(1).Save("account:Joey try to login failed"); //Received(1) 可以簡化成 Received()
//         }
//     }
// }