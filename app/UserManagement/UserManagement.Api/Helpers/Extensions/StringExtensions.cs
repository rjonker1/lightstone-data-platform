namespace UserManagement.Api.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string FirstNCharacters(this string theString, int index)
        {
            var totalLength = theString.Trim().Length;

            return index >= totalLength ? theString : theString.Substring(0, index);
        }

        public static string LastNCharacters(this string theString, int index)
        {
            var length = theString.Trim().Length;

            return index > length ? theString : theString.Substring((length - index), index);
        }
    }
}