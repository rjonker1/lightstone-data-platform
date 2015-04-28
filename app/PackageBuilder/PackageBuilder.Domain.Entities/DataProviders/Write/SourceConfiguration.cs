using System.Configuration;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;

namespace PackageBuilder.Domain.Entities.DataProviders.Write
{
    public class SourceConfiguration : ISourceConfiguration
    {
        private readonly DataProviderName _name;

        public SourceConfiguration(DataProviderName name)
        {
            _name = name;
        }

        public bool IsApiConfiguration
        {
            get
            {
                return string.IsNullOrEmpty(ConnectionString);
            }
        }

        public string Url
        {
            get
            {
                this.Info(() => "Attempting to find data provider Url for {0}".FormatWith(_name));

                var value = ConfigurationManager.AppSettings["{0}Url".FormatWith(_name.ToString())];

                this.Info(() => "Successfully found data provider Url for {0}".FormatWith(_name));

                return value;
            }
        }
        public string Username
        {
            get
            {
                this.Info(() => "Attempting to find data provider Username for {0}".FormatWith(_name));

                var value = ConfigurationManager.AppSettings["{0}Username".FormatWith(_name.ToString())];

                this.Info(() => "Successfully found data provider Username for {0}".FormatWith(_name));

                return value;
            }
        }
        public string Password
        {
            get
            {
                this.Info(() => "Attempting to find data provider Password for {0}".FormatWith(_name));

                var value = ConfigurationManager.AppSettings["{0}Password".FormatWith(_name.ToString())];

                this.Info(() => "Successfully found data provider Password for {0}".FormatWith(_name));

                return value;
            }
        }
        public string ConnectionString
        {
            get
            {
                this.Info(() => "Attempting to find data provider ConnectionString for {0}".FormatWith(_name));

                var value = ConfigurationManager.ConnectionStrings[_name.ToString()];

                this.Info(() => "Successfully found data provider ConnectionString for {0}".FormatWith(_name));

                return value != null ? value.ConnectionString : "";
            }
        }
    }
}