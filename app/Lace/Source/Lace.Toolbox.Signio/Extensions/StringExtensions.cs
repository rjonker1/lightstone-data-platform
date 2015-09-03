using System;

namespace Lace.Toolbox.Signio.Extensions
{
    public static class StringExtensions
    {
        public static string WithUserId(this string value, Guid userId)
        {
            return string.Format("{0}/{1}", value, userId);
        }
    }
}
