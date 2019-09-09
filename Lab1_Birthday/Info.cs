using System;

namespace Lab1_Birthday
{
    public class Info
    {
        public bool IsBirthDay()
        {
            var dateTime = DateTime.Now;
            return dateTime.Day == GetToday().Day && dateTime.Month == GetToday().Month;
        }

        protected virtual DateTime GetToday()
        {
            return DateTime.Now;
        }
    }
}