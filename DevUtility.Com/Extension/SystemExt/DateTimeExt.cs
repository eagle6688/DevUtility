using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemExt
{
    public static class DateTimeExt
    {
        #region To timestamp

        public static int ToTimeStamp(this DateTime datetime)
        {
            TimeSpan time = (datetime - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime());
            return (int)time.TotalSeconds;
        }

        #endregion

        #region Get day of week

        public static string ToDayOfWeek(this DateTime datetime)
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return weekdays[int.Parse(datetime.DayOfWeek.ToString("D"))];
        }

        #endregion

        #region Is weekend

        public static bool IsWeekend(this DateTime datetime)
        {
            int index = int.Parse(datetime.DayOfWeek.ToString("D"));
            return index == 0 || index == 6;
        }

        #endregion

        #region To long DateTime string

        public static string ToLongDateTimeString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        #endregion
    }
}