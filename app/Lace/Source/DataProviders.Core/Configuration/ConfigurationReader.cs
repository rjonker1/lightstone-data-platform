using System;
using System.Configuration;

namespace Lace.Domain.DataProviders.Core.Configuration
{
    public static class ConfigurationReader
    {
        public static string ReadAppSetting(string key, bool throwOnMissing = true)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value) && throwOnMissing)
                throw new Exception(string.Format("Could not find a value for key '{0}'", key));

            return value;
        }

        public static string ReadConnectionString(string key, bool throwOnMissing = true)
        {
            var value = ConfigurationManager.ConnectionStrings[key];
            if (value == null && throwOnMissing)
                throw new Exception(string.Format("Could not find a value for key '{0}'", key));

            return value == null ? string.Empty : value.ConnectionString;
        }
    }
}