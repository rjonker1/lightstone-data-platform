using System;
using System.Linq;

namespace Lim.Domain.Extensions
{
    public static class NumberExtensions
    {
        public static bool HasDigit(this string value)
        {
            return !string.IsNullOrEmpty(value) && value.Any(Char.IsDigit);
        }

        public static int Check(this string value)
        {
            try
            {
                return checked(int.Parse(value));
            }
            catch
            {
                return -1;
            }
        }

        public static TimeSpan Seconds(this int value)
        {
            var fromSeconds = TimeSpan.FromSeconds(value);

            return fromSeconds;
        }

        public static RepeatValue Times(this int value)
        {
            return new RepeatValue(value);
        }
    }
}
