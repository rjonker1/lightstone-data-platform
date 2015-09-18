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
    }
}
