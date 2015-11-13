using System;
namespace Lim.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static string YearMonthDay(this DateTime date)
        {
            return date.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
