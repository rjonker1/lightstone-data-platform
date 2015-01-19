using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Helpers;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    public class SourceConfiguration
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

                var url = DataProviderSourceConfiguration.Url(_name);

                this.Info(() => "Successfully found data provider Url for {0}".FormatWith(_name));

                return url;
            }
        }
        public string Username
        {
            get
            {
                this.Info(() => "Attempting to find data provider Username for {0}".FormatWith(_name));

                var username = DataProviderSourceConfiguration.Username(_name);

                this.Info(() => "Successfully found data provider Username for {0}".FormatWith(_name));

                return username;
            }
        }
        public string Password
        {
            get
            {
                this.Info(() => "Attempting to find data provider Password for {0}".FormatWith(_name));

                var password = DataProviderSourceConfiguration.Password(_name);

                this.Info(() => "Successfully found data provider Password for {0}".FormatWith(_name));

                return password;
            }
        }
        public string ConnectionString
        {
            get
            {
                this.Info(() => "Attempting to find data provider ConnectionString for {0}".FormatWith(_name));

                var connectionString = DataProviderSourceConfiguration.ConnectionString(_name);

                this.Info(() => "Successfully found data provider ConnectionString for {0}".FormatWith(_name));

                return connectionString;
            }
        }
    }
}