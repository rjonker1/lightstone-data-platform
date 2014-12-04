using System.Configuration;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;

namespace PackageBuilder.Core.Helpers
{
    public class DataProviderSourceConfiguration
    {
        public static string Url(DataProviderName name)
        {
            var value = ConfigurationManager.AppSettings["{0}Url".FormatWith(name.ToString())];
            return value == null || !value.Any() ? "" : value;
        }
        public static string Username(DataProviderName name)
        {
            var value = ConfigurationManager.AppSettings["{0}Username".FormatWith(name.ToString())];
            return value == null || !value.Any() ? "" : value;
        }
        public static string Password(DataProviderName name)
        {
            var value = ConfigurationManager.AppSettings["{0}Password".FormatWith(name.ToString())];
                return value == null || !value.Any() ? "" : value;
        }
        public static string ConnectionString(DataProviderName name)
        {
            var value = ConfigurationManager.ConnectionStrings[name.ToString()];
            return value == null ? "" : value.ConnectionString;
        }
    }
}