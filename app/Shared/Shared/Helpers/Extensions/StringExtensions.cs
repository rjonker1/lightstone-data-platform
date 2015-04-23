using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DataPlatform.Shared.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string ToUri(this string value)
        {
            return value.ToNullSafeString().Replace("_", " ").Replace("-", " ").Clean().Replace("--", "-");
        }

        public static string ToNullSafeString(this object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        /// <summary>
        /// Cleanses String for URL
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>URL Friendly String</returns>
        private static string Clean(this string s)
        {
            var sb = new StringBuilder(Regex.Replace(HttpUtility.HtmlDecode(s).RemoveAccent(), @"[^\w\s]", "").Trim());
            sb = sb.Replace(" ", "-").Replace("--", "-");

            return sb.ToString().ToLower();
        }

        /// <summary>
        /// Convert Foreign Accent Characters
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>Common ASCII representation</returns>
        private static string RemoveAccent(this string s)
        {
            return Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(s));
        }

        /// <summary>
        /// Replaces all multiple spaces in the provided string with single spaces. Eg "test   sentence" becomes "test sentence"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", " ", RegexOptions.None);
        }

        /// <summary>
        /// Converts a uri to a title
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static string UriToTitle(this string theString)
        {
            return theString.ToNullSafeString().Replace("-", " ").ToTitleCase();
        }

        static public string ToTitleCase(this string text)
        {
            if (text == null) text = string.Empty;
            var info = CultureInfo.CurrentCulture.TextInfo;
            return info.ToTitleCase(text);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format ?? string.Empty, args);
        }

        public static string SplitCamelCase(this string camelCaseString)
        {
            return Regex.Replace(camelCaseString, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }
}