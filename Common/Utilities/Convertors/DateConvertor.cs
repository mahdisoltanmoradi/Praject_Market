using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common.Utilities.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar persian = new PersianCalendar();
            return persian.GetYear(value) + "/" + persian.GetMonth(value).ToString("00") + "/" +
            persian.GetDayOfMonth(value).ToString("00");
        }
    }
}
