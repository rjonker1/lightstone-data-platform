using DataPlatform.Shared.Enums;
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
                return DataProviderSourceConfiguration.Url(_name);
            }
        }
        public string Username
        {
            get
            {
                return DataProviderSourceConfiguration.Username(_name);
            }
        }
        public string Password
        {
            get
            {
                return DataProviderSourceConfiguration.Password(_name);
            }
        }
        public string ConnectionString
        {
            get
            {
                return DataProviderSourceConfiguration.ConnectionString(_name);
            }
        }
    }
}