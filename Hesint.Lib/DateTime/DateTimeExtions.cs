using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.Lib.DateTimes
{
    public static class DateTimeExtions
    {
        public static TimeSpan GetTimeSpan(this DateTime dateTime,DateTime endDateTime)
        {
            return endDateTime - dateTime;
        }
    }
}
