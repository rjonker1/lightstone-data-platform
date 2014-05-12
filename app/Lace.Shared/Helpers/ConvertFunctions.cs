﻿using System;
namespace Lace.Shared.Helpers
{
    public class ConvertFunctions
    {
        public static T ConvertObject<T>(Object input)
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }

    }
}
