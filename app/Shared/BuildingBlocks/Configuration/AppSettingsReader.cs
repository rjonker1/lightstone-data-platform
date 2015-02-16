using System;
using System.Configuration;
using Common.Logging;

namespace Shared.Configuration
{
    internal class AppSettingsReader
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public string GetString(string key, Func<string> ifMissing)
        {
            log.InfoFormat("Looking for {0} in the appSettings", key);

            var value = ConfigurationManager.AppSettings.Get(key);
            var @default = ifMissing();

            if (!string.IsNullOrEmpty(value)) 
                return value;

            log.DebugFormat("Did not find {0} in appSettings. Using default: {1}", key, @default);
            return @default;
        }
    }
}