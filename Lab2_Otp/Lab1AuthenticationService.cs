using System;
using System.Collections.Generic;

namespace Lab2_Otp
{
    public class Lab1AuthenticationService
    {
        private IProfileDao _profileDao;
        private IRsaTokenDao _rsaTokenDao;
        private ILogService _logService;

        public Lab1AuthenticationService(IProfileDao profileDao, IRsaTokenDao rsaTokenDao, ILogService logService)
        {
            _profileDao = profileDao;
            _rsaTokenDao = rsaTokenDao;
            _logService = logService;
        }

        public bool IsValid(string account, string passcode)
        {
            // 根據 account 取得自訂密碼
            var profileDao = _profileDao;
            var passwordFromDao = profileDao.GetPassword(account);

            // 根據 account 取得 RSA token 目前的亂數
            var rsaToken = _rsaTokenDao;
            var randomCode = rsaToken.GetRandom(account);

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;
            var isValid = passcode == validPassword;

            if(isValid)
            {
                return true;
            }
            else
            {
                string message = $"account={account}";
                _logService.Log(message);
                return false;
            }
        }
    }

    public interface ILogService
    {
        void Log(string message);
    }

    public class LogService : ILogService
    {
        public void Log(string message)
        {
        }
    }

    public interface IProfileDao
    {
        string GetPassword(string account);
    }

    public class ProfileDao : IProfileDao
    {
        public string GetPassword(string account)
        {
            return Context.GetPassword(account);
        }
    }

    public static class Context
    {
        public static Dictionary<string, string> profiles;

        static Context()
        {
            profiles = new Dictionary<string, string>();
            profiles.Add("joey", "91");
            profiles.Add("mei", "99");
        }

        public static string GetPassword(string key)
        {
            return profiles[key];
        }
    }

    public interface IRsaTokenDao
    {
        string GetRandom(string account);
    }

    public class RsaTokenDao : IRsaTokenDao
    {
        public string GetRandom(string account)
        {
            var seed = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var result = seed.Next(0, 999999).ToString("000000");
            Console.WriteLine("randomCode:{0}", result);

            return result;
        }
    }
}