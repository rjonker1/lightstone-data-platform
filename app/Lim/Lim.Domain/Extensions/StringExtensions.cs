using System.Text.RegularExpressions;

namespace Lim.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Fix(this string value)
        {
            return (value ?? "").Trim();
        }

        public static string RemoveWhiteSpace(this string value)
        {
            return Regex.Replace(value ?? "", @"\s+", "");
        }
    }
}
