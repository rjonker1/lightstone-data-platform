using System;
namespace Lace.Source.Helpers
{
    public static class ConvertFunctions
    {
        public static T ConvertObject<T>(Object input)
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }

    }
}
