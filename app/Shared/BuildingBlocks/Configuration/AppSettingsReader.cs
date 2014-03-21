using System;
using System.Configuration;

namespace BuildingBlocks.Configuration
{
    internal class AppSettingsReader
    {
        public string GetString(string key, Func<string> ifMissing)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            return string.IsNullOrEmpty(value) ? ifMissing() : value;
        }
    }
}