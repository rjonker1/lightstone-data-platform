namespace Lace.Domain.DataProviders.Core.Configuration
{
    public static class SignioDriversLicenseConfiguration
    {
        public static readonly string Url = ConfigurationReader.ReadAppSetting("drivers/license/decryption/url");
        public static readonly string Suffix = ConfigurationReader.ReadAppSetting("drivers/license/decryption/suffix");
        public static readonly string Username = ConfigurationReader.ReadAppSetting("drivers/license/decryption/username");
        public static readonly string Password = ConfigurationReader.ReadAppSetting("drivers/license/decryption/password");
        public static readonly string Token = ConfigurationReader.ReadAppSetting("drivers/license/decryption/token");
        public static readonly string Key = ConfigurationReader.ReadAppSetting("drivers/license/decryption/key");
    }

    public static class LightstoneBusinessConfiguration
    {
        public static readonly string Username = ConfigurationReader.ReadAppSetting("lightstone/business/api/username");
        public static readonly string Password = ConfigurationReader.ReadAppSetting("lightstone/business/api/password");
    }

    public static class IvidConfiguration
    {
        public static readonly string Username = ConfigurationReader.ReadAppSetting("ivid/username");
        public static readonly string Password = ConfigurationReader.ReadAppSetting("ivid/password");
    }

    public static class IvidTitleHolderConfiguration
    {
        public static readonly string Username = ConfigurationReader.ReadAppSetting("ividtitleholder/username");
        public static readonly string Password = ConfigurationReader.ReadAppSetting("ividtitleholder/password");
    }

    public static class AutoCarstatsConfiguration
    {
        public static readonly string Database = ConfigurationReader.ReadConnectionString("lace/source/database/auto-car-stats");
    }

    public static class FinancedInterestsConfiguration
    {
        public static readonly string Database = ConfigurationReader.ReadConnectionString("lace/source/database/financed-interests");
    }


    public static class WorkflowConfiguration
    {
        public static readonly string MonitoringDatabase = ConfigurationReader.ReadConnectionString("workflow/monitoring/database");
        public static readonly string TransactionDatabase = ConfigurationReader.ReadConnectionString("workflow/transactions/database");
        public static readonly string ServiceDescription = ConfigurationReader.ReadAppSetting("service/config/description");
        public static readonly string ServiceName = ConfigurationReader.ReadAppSetting("service/config/name");
        public static readonly string ServiceDisplayName = ConfigurationReader.ReadAppSetting("service/config/displayName");
    }

    public static class CachingConfiguration
    {
        public static readonly string ServiceDescription = ConfigurationReader.ReadAppSetting("service/config/description");
        public static readonly string ServiceName = ConfigurationReader.ReadAppSetting("service/config/name");
        public static readonly string ServiceDisplayName = ConfigurationReader.ReadAppSetting("service/config/displayName");
    }

    public static class LightstoneConsumerConfiguration
    {
        public static readonly string Accesskey = ConfigurationReader.ReadAppSetting("lightstone/conumser/specifications/accesskey");
    }

}
