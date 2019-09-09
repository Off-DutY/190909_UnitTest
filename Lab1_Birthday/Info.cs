using System;

namespace Lab1_Birthday
{
    public class Info
    {
        private readonly DateTime _myBirthDate = DateTime.Now;

        public bool IsBirthDay()
        {
            return _myBirthDate.Day == GetToday().Day && _myBirthDate.Month == GetToday().Month;
        }

        protected virtual DateTime GetToday()
        {
            return DateTime.Now;
        }
    }
}