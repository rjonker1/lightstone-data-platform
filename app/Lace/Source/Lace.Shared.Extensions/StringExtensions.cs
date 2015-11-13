namespace Lace.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string Fix(this string val)
        {
            return (val ?? "").Trim();
        }

        public static bool Exists(this string val)
        {
            return !string.IsNullOrEmpty(val);
        }
    }
}
