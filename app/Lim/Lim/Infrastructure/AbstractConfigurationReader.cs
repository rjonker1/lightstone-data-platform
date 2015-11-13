using System.Configuration;
namespace Lim.Infrastructure
{
    public class AbstractConfigurationReader
    {
        protected string GetAppSetting(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        protected string GetConnectionString(string key, string defaultValue)
        {
            var value = ConfigurationManager.ConnectionStrings[key];

            if (value == null)
                return defaultValue;

            return string.IsNullOrEmpty(value.ConnectionString) ? defaultValue : value.ConnectionString;
        }
    }
}