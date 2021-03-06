﻿using System.IO;
using Recoveries.Core;

namespace Recoveries.Shared
{
    public static class Extensions
    {
        public static T Get<T>(this IQueueOptions options, string property)
        {
            var obj = options.GetType().GetProperty(property).GetValue(options, null);
            return (T)obj;
        }

        public static void CreateDirectory(this string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
