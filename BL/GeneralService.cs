﻿using DL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class GeneralService
    {
        public static bool IsNaturalNumber(string s)
        {
            if (int.TryParse(s, out int i) && i >= 0)
            {
                return true;
            }
            else
                return false;
        }

        public static DateTimeOffset LocalDateTimeOffset()
        {
            return DateTimeOffset.UtcNow.ToLocalTime();
        }

        public static DateTimeOffset ConvertStringToDateTimeOffset(string dateTimeString, string format)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, TimeSpan.FromHours(7));
            return dateTimeOffset;
        }

        public static string ConvertDateTimeOffsetToString(DateTimeOffset dateTime, string format = "yyyy-MM-dd HH:mm:ss zzz")
        {
            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }

        public static decimal ConvertFromCurrency(string currencyValue)
        {
            return decimal.Parse(currencyValue, NumberStyles.Currency, new CultureInfo("vi-VN"));
        }

        public static string ConvertToCurrency(decimal value)
        {
            return value.ToString("C", new CultureInfo("vi-VN"));
        }

    }
}
