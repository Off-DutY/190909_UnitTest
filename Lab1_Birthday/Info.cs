using System;

namespace Lab1_Birthday
{
    public class Info
    {
        private readonly DateTimeHelper _dateTimeHelper;
        private readonly DateTime _myBirthDate = DateTime.Now;

        public Info(DateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        public bool IsBirthDay()
        {
            var today = _dateTimeHelper.GetToday();
            return _myBirthDate.Day == today.Day && _myBirthDate.Month == today.Month;
        }
    }

    public class DateTimeHelper
    {
        public virtual DateTime GetToday()
        {
            return DateTime.Now;
        }
    }
}