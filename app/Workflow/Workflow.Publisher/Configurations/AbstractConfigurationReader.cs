using System;
using System.Configuration;

namespace Workflow.Publisher.Configurations
{
    public abstract class AbstractConfigurationReader
    {
        protected string ReadAppSettings(string key, bool throwOnMissing = true)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value) && throwOnMissing)
                throw new Exception(string.Format("Could not find a value for key '{0}'", key));

            return value;
        }

        protected string ReadAppSettings(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];

            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        public string ReadConnectionStringValue(string key, bool throwOnMissing = true)
        {
            var value = ConfigurationManager.ConnectionStrings[key];
            if (value == null && throwOnMissing)
                throw new Exception(string.Format("Could not find a value for key '{0}'", key));

            return value == null ? string.Empty : value.ConnectionString;
        }

        public ConnectionStringSettings ReadConnectionString(string key)
        {
            var value = ConfigurationManager.ConnectionStrings[key];
            if (value == null)
                throw new Exception(string.Format("Could not find a value for key '{0}'", key));

            return value;
        }

        public string ReadConnectionString(string key, string defaultValue)
        {
            var value = ConfigurationManager.ConnectionStrings[key];
            if (value == null)
                return defaultValue;

            return string.IsNullOrEmpty(value.ConnectionString) ? defaultValue : value.ConnectionString;
        }
    }
}