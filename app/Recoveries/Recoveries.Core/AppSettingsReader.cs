using System;
using System.Configuration;

namespace Recoveries.Core
{
    public sealed class AppSettingsReader
    {
        public static string GetString(string key, Func<string> @default)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            return string.IsNullOrEmpty(value) ? @default() : value;
        }

        public static int GetInt(string key, Func<int> @default)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            var @int = 0;
            return int.TryParse(value, out @int) ? @int : @default();
        }

        public static bool GetBool(string key, Func<bool> @default)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            var @bool = false;
            return bool.TryParse(value, out @bool) ? @bool : @default();
        }
    }
}
