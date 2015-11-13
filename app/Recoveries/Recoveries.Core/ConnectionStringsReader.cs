using System;
using System.Configuration;

namespace Recoveries.Core
{
    public sealed class ConnectionStringsReader
    {
        public static string Get(string key, Func<string> @default)
        {
            var value = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return string.IsNullOrEmpty(value) ? @default() : value;
        }
    }
}
