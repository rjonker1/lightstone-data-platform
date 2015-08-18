namespace Lace.Toolbox.PCubed.Extensions
{
    public static class StringExtensions
    {
        internal static string Fix(this string val)
        {
            return (val ?? "").Trim();
        }
    }
}
