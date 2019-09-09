using System;

namespace Lab1_Birthday
{
    public class Info
    {
        public bool IsBirthDay()
        {
            return BirthDay == DateTime.Now.Date;
        }

        public DateTime BirthDay { get; set; }
    }
}