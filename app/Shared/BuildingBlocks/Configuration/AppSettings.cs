using System.Configuration;

namespace Shared.Configuration
{
    public class AppSettings
    {
        private readonly AppSettingsReader reader = new AppSettingsReader();

        public AppSettings()
        {
            Service = new ServiceAppSettings(reader);
            ConnectionStrings = new ConnectionStrings(ConfigurationManager.ConnectionStrings);
            RabbitMQ = new RabbmitMQSettings(reader);
            Api = new ApiSettings(reader);
            PackageBuilderApi = new PackageBuilderApiSettings(reader);
            UserManagementApi = new UserManagementApiSettings(reader);
            BillingApi = new BillingApiSettings(reader);
            ReportApi = new ReportApiSettings(reader);
        }

        public ServiceAppSettings Service { get; private set; }
        public ConnectionStrings ConnectionStrings { get; private set; }
        public RabbmitMQSettings RabbitMQ { get; private set; }
        public ApiSettings Api { get; private set; }
        public UserManagementApiSettings UserManagementApi { get; private set; }
        public PackageBuilderApiSettings PackageBuilderApi { get; private set; }
        public BillingApiSettings BillingApi { get; private set; }
        public ReportApiSettings ReportApi { get; private set; }
    }
}
