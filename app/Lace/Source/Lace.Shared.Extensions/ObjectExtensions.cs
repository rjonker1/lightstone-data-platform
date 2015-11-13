using System;

namespace Lace.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            return obj == null || String.IsNullOrEmpty(obj.ToString());
        }
    }
}
